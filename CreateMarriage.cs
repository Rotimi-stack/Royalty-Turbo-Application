using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class CreateMarriage : Form
    {
        private MarriageData _mar;
        public readonly ISQL _db;
        private IMemberController _memberController;
        
        private CodeMarriageStatusType _status;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateMarriage(string connectionString, MarriageData marriage = null)
        {
            InitializeComponent();
            SetCurvedEdges();
            _mar = marriage ?? new MarriageData(); // If no member is provided, create a new one
            _isEditMode = marriage != null;
            _memberController = new MemberController(connectionString);
            
           
            _status = new CodeMarriageStatusType();
            _setUpController = new SetUpController(connectionString);
            MakePanelCircular(panel3);
            ClearInputFields();
            LoadCodeTable();

            if (_isEditMode)
            {
                PopulateFields();
            }
            else
            {
                ClearInputFields();
            }
            

        }
        private void MakePanelCircular(Panel panel)
        {
            // Resize the panel to 100x100 pixels
            panel.Size = new Size(50, 50);

            // Create a circular region for the panel
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }
        private void PopulateFields()
        {
            
            txtCp.Text = _mar.CoupleName;
            txtCC.Text = _mar.CertificateName;

            
            cmbSt.SelectedIndex = cmbSt.FindStringExact(_mar.StatusDescrip);
            txtRea.Text = _mar.Reason;
            txtOffi.Text = _mar.OfficiatingMinisters;
            dtpMarDate.Value = _mar.DateCreated;
            dtpMarDate.Value = _mar.ScheduledDate;

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
        private void ClearInputFields()
        {
            // Clear input fields

            txtCp.Text = "";
            txtCC.Text = "";
            cmbSt.Text = "";
            txtRea.Text = "";
            txtOffi.Text = "";

            cmbSt.SelectedIndex = -1;
            cmbSt.Update();

        }
        protected void LoadCodeTable()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeMarriageStatusType);

            cmbSt.DataSource = null;
            cmbSt.Items.Clear();

            cmbSt.Items.Add("");
            if (staType.Count > 0)
            {
                cmbSt.DataSource = staType;
                cmbSt.ValueMember = "Code";
                cmbSt.DisplayMember = "Descrip";
            }
            cmbSt.DropDownStyle = ComboBoxStyle.DropDownList;

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
        private async void btnAddMarriage_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                var getMarriage = _memberController.GetMemberByEmail(txtCp.Text);
                if (getMarriage != null)
                {
                    DisplayMessage("Marriage details already captured", MessageBoxIcon.Error);
                    ClearInputFields(); // Clear input fields after successful save
                    return;
                }
            }



            Control ctlr = this;
            string strError = null;
            _mar.CoupleName = txtCp.Text;
            _mar.Status = cmbSt.Text;
            _mar.CertificateName=txtCC.Text;
            _mar.OfficiatingMinisters = txtOffi.Text;
            _mar.Reason=txtRea.Text;


            if (string.IsNullOrWhiteSpace(_mar.CoupleName))
            {
                ctlr = txtCp;
                strError = "Please enter Couples Name";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_mar.CertificateName))
            {
                ctlr = txtCC;
                strError = "Please enter issued certificate Name";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_mar.OfficiatingMinisters))
            {
                ctlr = txtOffi;
                strError = "Please enter officiating ministers Name";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_mar.CoupleName))
            {
                ctlr = txtCp;
                strError = "Please enter Couples Name";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (cmbSt.SelectedIndex != -1)
            {
                _mar.Status = cmbSt.SelectedValue.ToString();

            }

            else
            {
                ctlr = cmbSt;
                strError = "Please enter Status";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;

            }


            _mar.ScheduledDate = dtpMarDate.Value.Date;
            _mar.DateCreated = dtpMarriage.Value.Date;
            _mar.DateModified = dtpMarriage.Value.Date;

            if (_isEditMode)
            {
                // Call the Update method in the MemberController
                bool updateResult = await _memberController.UpdateMarriage(_mar);

                if (updateResult)
                {
                    DisplayMessage("Member updated successfully!", MessageBoxIcon.Information);
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
                bool saveResult = await _memberController.SaveMarriage(_mar);

                if (saveResult)
                {
                    DisplayMessage("Marriage added successfully!", MessageBoxIcon.Information);
                    ClearInputFields(); // Clear input fields after successful save
                }
                else
                {
                    DisplayMessage("Error occurred while saving member!", MessageBoxIcon.Error);
                }
            }




        }



      

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
