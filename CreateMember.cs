using Microsoft.Extensions.Configuration;
using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class CreateMember : Form
    {
        private MemberData _mem;
        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeStateType _state;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateMember(string connectionString, MemberData member = null)
        {
            InitializeComponent();
            SetCurvedEdges();


            _mem = member ?? new MemberData(); // If no member is provided, create a new one
            _isEditMode = member != null;
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _setUpController = new SetUpController(connectionString);

            MakePanelCircular(panel4);
            LoadCodeTable();

            if (_isEditMode)
            {
                PopulateFields();
            }
            else
            {
                ClearInputFields();
            }
            //ClearInputFields();
        }

        private void PopulateFields()
        {
            textfname.Text = _mem.Firstname;
            textLname.Text = _mem.Lastname;
            textMname.Text = _mem.Middlename;
            textAddress.Text = _mem.Address;
            textEmail.Text = _mem.Email;
            textReason.Text = _mem.Reason;
            textPhone.Text = _mem.PhoneNumber;
            textMembershipNo.Text = _mem.MembershipNo.ToString();
            textDepartment.Text = _mem.Department;
            textOccupation.Text = _mem.Occupation;
            cmbGender.SelectedValue = _mem.Sex;
            dateTimePicker1.Value = _mem.DateCreated;
            cmbStatus.SelectedIndex = cmbStatus.FindStringExact(_mem.Status);
            cmbNat.SelectedIndex = cmbNat.FindStringExact(_mem.Nationality);
            cmbState.SelectedIndex = cmbState.FindStringExact(_mem.State);
          



        }

        private void MakePanelCircular(Panel panel)
        {
            // Resize the panel to 100x100 pixels
            panel.Size = new Size(40, 40);

            // Create a circular region for the panel
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, panel.Width, panel.Height);
            panel.Region = new Region(path);
        }
        private void ClearInputFields()
        {
            // Clear input fields
            textfname.Text = "";
            textLname.Text = "";
            textMname.Text = "";
            textAddress.Text = "";
            textEmail.Text = "";
            cmbStatus.Text = "";
            textReason.Text = "";
            textPhone.Text = "";
            textMembershipNo.Text = "";
            textDepartment.Text = "";
            textOccupation.Text = "";

            cmbNat.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbGender.SelectedIndex = -1;

            cmbNat.Text = "";
            cmbStatus.Text = "";
            cmbGender.Text = "";
            cmbState.Text = "";




            cmbState.Update();
            cmbNat.Update();
            cmbGender.Update();
            cmbNat.Update();


        }
        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            int newWidth = 820;
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

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        //Load the code desriptions of the types from the table
        protected void LoadCodeTable()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeStatusType);

            cmbStatus.DataSource = null;
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("");
            if (staType.Count > 0)
            {
                cmbStatus.DataSource = staType;
                cmbStatus.ValueMember = "Code";
                cmbStatus.DisplayMember = "Descrip";
            }
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;





            List<CodeTypeData> nat = _setUpController.GetCodeTable(Utility.CodeTable.CodeNationalityType);
            cmbNat.DataSource = null;
            cmbNat.Items.Clear();

            cmbNat.Items.Add("");

            if (nat.Count > 0)
            {


                cmbNat.DataSource = nat;
                cmbNat.ValueMember = "Code";
                cmbNat.DisplayMember = "Descrip";

            }
            cmbNat.DropDownStyle = ComboBoxStyle.DropDownList;



            List<CodeTypeData> state = _setUpController.GetCodeTable(Utility.CodeTable.CodeStateType);
            cmbState.DataSource = null;
            cmbState.Items.Clear();

            cmbState.Items.Add("");

            if (state.Count > 0)
            {


                cmbState.DataSource = state;
                cmbState.ValueMember = "Code";
                cmbState.DisplayMember = "Descrip";

            }
            cmbState.DropDownStyle = ComboBoxStyle.DropDownList;




            List<CodeTypeData> sex = _setUpController.GetCodeTable(Utility.CodeTable.CodeSexType);
            cmbGender.DataSource = null;
            cmbGender.Items.Clear();

            cmbGender.Items.Add("");

            if (sex.Count > 0)
            {


                cmbGender.DataSource = sex;
                cmbGender.ValueMember = "Code";
                cmbGender.DisplayMember = "Descrip";

            }
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;

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
        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            {
                if (!_isEditMode)
                {
                    var getWorker = _memberController.GetMemberByEmail(textEmail.Text);
                    if (getWorker != null)
                    {
                        DisplayMessage("Worker details already captured", MessageBoxIcon.Error);
                        ClearInputFields(); // Clear input fields after successful save
                        return;
                    }
                }


                Control ctlr = this;
                string strError = null;
                _mem.Firstname = textfname.Text;
                _mem.Lastname = textLname.Text;
                _mem.Middlename = textMname.Text;
                _mem.Address = textAddress.Text;
                _mem.Email = textEmail.Text;
                _mem.Status = cmbStatus.Text;
                _mem.Reason = textReason.Text;
                _mem.State = cmbState.Text;
                _mem.Nationality = cmbNat.Text;
                _mem.PhoneNumber = textPhone.Text;
                _mem.Sex = cmbGender.Text;
                //_mem.MembershipNo = int.Parse(textMembershipNo.Text);
                _mem.Department = textDepartment.Text;
                _mem.Occupation = textOccupation.Text;



                if (!int.TryParse(textMembershipNo.Text, out int membershipNo))
                {
                    ctlr = textMembershipNo;
                    strError = "Please enter a valid Membership No";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                _mem.MembershipNo = membershipNo;


                if (string.IsNullOrWhiteSpace(_mem.Firstname))
                {
                    ctlr = textfname;
                    strError = "Please enter Firstname";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_mem.Lastname))
                {
                    ctlr = textLname;
                    strError = "Please enter Lastname";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_mem.Middlename))
                {
                    ctlr = textMname;
                    strError = "Please enter Middlename";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_mem.Address))
                {
                    ctlr = textAddress;
                    strError = "Please enter Address";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrWhiteSpace(_mem.Occupation))
                {
                    ctlr = textOccupation;
                    strError = "Please enter Occupation";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }

                if (cmbStatus.SelectedIndex != -1)
                {
                    _mem.Status = cmbStatus.SelectedValue.ToString();

                }

                else
                {
                    ctlr = cmbStatus;
                    strError = "Please enter Status";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }

                if (cmbGender.SelectedIndex != -1)
                {
                    _mem.Sex = cmbGender.SelectedValue.ToString();

                }

                else
                {
                    ctlr = cmbGender;
                    strError = "Please enter Gender";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }

                if (cmbNat.SelectedIndex != -1)
                {
                    _mem.Nationality = cmbNat.SelectedValue.ToString();

                }

                else
                {
                    ctlr = cmbNat;
                    strError = "Please enter Nationality";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }

                if (cmbState.SelectedIndex != -1)
                {
                    _mem.State = cmbState.SelectedValue?.ToString();

                }
                else
                {
                    ctlr = cmbState;
                    strError = "Please enter State";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }

                _mem.DateCreated = dateTimePicker1.Value.Date;
                _mem.DateModified = dateTimePicker1.Value.Date;
                if (_isEditMode)
                {
                    // Call the Update method in the MemberController
                    bool updateResult = await _memberController.Update(_mem);

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
                    bool saveResult = await _memberController.Save(_mem);

                    if (saveResult)
                    {
                        DisplayMessage("Member added successfully!", MessageBoxIcon.Information);
                        ClearInputFields(); // Clear input fields after successful save
                    }
                    else
                    {
                        DisplayMessage("Error occurred while saving member!", MessageBoxIcon.Error);
                    }
                }
            }
        }

       
    }
}
