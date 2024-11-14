using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class CreateEquipment : Form
    {

     
        private EquipmentData _equ;
        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeStateType _state;
        private CodeEquipmentStatusType _equip;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateEquipment(string connectionString, EquipmentData equipment = null)
        {
            InitializeComponent();
            SetCurvedEdges();
            
            _equ = equipment ?? new EquipmentData();
            _isEditMode = equipment != null;
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _equip=new CodeEquipmentStatusType();
            _setUpController = new SetUpController(connectionString);
            LoadCodeTable();
            MakePanelCircular(panel7);
            ClearInputFields();


            if (_isEditMode)
            {
                PopulateFields();

            }
            else
            {
                ClearInputFields();
            }


        }
        private void PopulateFields()
        {

            textEquName.Text = _equ.EquipmentName;
            textEqpBrand.Text = _equ.Brand;
            cmbEqupStatus.SelectedIndex = cmbEqupStatus.FindStringExact(_equ.StatusDescrip);
            textQty.Text= _equ.Quantity.ToString();
            textPurPrice.Text = _equ.PurchasePrice.ToString();
            dtpPurDate.Value = _equ.PurchasedDate;

            textEquName.Enabled = false;
            textEqpBrand.Enabled= false;
            textPurPrice.Enabled = false;

        }
        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            int newWidth = 500;
            int newHeight = 500;

            // Define the radius of the curves (adjust as needed)
            int radius = 20;

            // Create a GraphicsPath to define the shape
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, 0, radius * 2, radius * 2), -90, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, newHeight - radius * 2, radius * 2, radius * 2), 0, 90);
            path.AddArc(new Rectangle(0, newHeight - radius * 2, radius * 2, radius * 2), 90, 90);
            path.CloseFigure();

            // Set the form's region to the defined shape
            this.Region = new Region(path);

            // Set the new size of the form
            this.Size = new Size(newWidth, newHeight);
        }

        private void MakePanelCircular(Panel panel)
        {
            // Resize the panel to 100x100 pixels
            panel.Size = new Size(40, 50);

            // Create a circular region for the panel
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }
        protected void LoadCodeTable()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeEquipmentStatusType);

            cmbEqupStatus.DataSource = null;
            cmbEqupStatus.Items.Clear();

            cmbEqupStatus.Items.Add("");
            if (staType.Count > 0)
            {
                cmbEqupStatus.DataSource = staType;
                cmbEqupStatus.ValueMember = "Code";
                cmbEqupStatus.DisplayMember = "Descrip";
            }
            cmbEqupStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Member", MessageBoxButtons.OK, icon);
            Task.Delay(timeout).ContinueWith(t =>
            {
                if (IsHandleCreated)
                {
                    Invoke(new Action(() =>
                    {
                        errorProvider1.Clear();
                    }));
                }
            });
        }
        private void ClearInputFields()
        {
            // Clear input fields
            textEquName.Text = "";
            textEqpBrand.Text = "";
            textPurPrice.Text = "";
            cmbEqupStatus.SelectedIndex = -1;

           

            cmbEqupStatus.Update();



        }
        private async void btnAddEquip_Click(object sender, EventArgs e)
        {
            {

                Control ctlr = this;
                string strError = null;
                _equ.EquipmentName = textEquName.Text;
                _equ.Brand = textEqpBrand.Text;
                _equ.Status = cmbEqupStatus.Text;
                _equ.Quantity=int.Parse(textQty.Text);
                _equ.PurchasePrice = decimal.Parse(textPurPrice.Text);
                _equ.PurchasedDate = dtpPurDate.Value.Date;



                if (string.IsNullOrWhiteSpace(_equ.EquipmentName))
                {
                    ctlr = textEquName;
                    strError = "Please enter Firstname";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_equ.Brand))
                {
                    ctlr = textEqpBrand;
                    strError = "Please enter Lastname";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textQty.Text, out int quantity))
                {
                    ctlr = textQty;
                    strError = "Please enter a valid Membership No";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                _equ.Quantity = quantity;


                if (cmbEqupStatus.SelectedIndex != -1)
                {
                    _equ.Status = cmbEqupStatus.SelectedValue.ToString();

                }

                else
                {
                    ctlr = cmbEqupStatus;
                    strError = "Please enter Status";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }

                if (decimal.TryParse(textPurPrice.Text.Replace(",", ""), out decimal amount))
                {
                    _equ.PurchasePrice = amount;
                    textPurPrice.Text = string.Format(CultureInfo.InvariantCulture, "{0:N}", amount);
                }
                else
                {
                    ctlr = textPurPrice;
                    strError = "Please input Amount";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }

                _equ.DateModified = dtpPurDate.Value.Date;
                _equ.DateCreated = dtpPurDate.Value.Date;

                if (_isEditMode)
                {
                    // Call the Update method in the MemberController
                    bool updateResult = await _memberController.UpdateEquipment(_equ);

                    if (updateResult)
                    {
                        DisplayMessage("Equipment updated successfully!", MessageBoxIcon.Information);
                        this.Close(); // Close the form after successful update
                    }
                    else
                    {
                        DisplayMessage("Error occurred while updating member!", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Call the Save method in the MemberController
                    bool saveResult = await _memberController.SaveEquipment(_equ);

                    if (saveResult)
                    {
                        DisplayMessage("Equipment added successfully!", MessageBoxIcon.Information);
                        ClearInputFields(); // Clear input fields after successful save
                    }
                    else
                    {
                        DisplayMessage("Error occurred while adding equipment!", MessageBoxIcon.Error);
                    }
                }

            }
        }
       
        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

       
    }
}
