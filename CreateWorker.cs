using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace Royalty_Turbo
{
    public partial class CreateWorker : Form
    {

        #region Variables

        private MemberData _mem;
        private WorkerData _wor;
        private PromotionData _pro;
        private MarriageData _marriage;
        private DedicationData _dedication;
        private DepartmentRecordData _record;
        private EquipmentData _equipment;
        private ProgramItenaryData _program;



        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeStateType _state;
        private ISetUpController _setUpController;
        #endregion
        private string _connectionString;
        public CreateWorker(string connectionString)
        {
            InitializeComponent();
            SetCurvedEdges();
            textfname2.Enabled = false;
            cmbStatus3.Enabled = false;
            cmbGender3.Enabled = false;
            textMname2.Enabled = false;
            textLname2.Enabled = false;
            textReason2.Enabled = false;
            textPhone2.Enabled = false;
            textDepartment2.Enabled = false;
            textMembershipNo2.Enabled = false;
            btnAddworker.Enabled = false;
            btnUpdate.Enabled = false;
            dateTimePicker3.Enabled = true;
            





            _connectionString = connectionString;
            _mem = new MemberData();
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _setUpController = new SetUpController(connectionString);
            MakePanelCircular(panel3);

            LoadCodeTable();
            ClearInputFields();


            //ClearInputFields();


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
        protected void LoadCodeTable()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeStatusType);

            cmbStatus3.DataSource = null;
            cmbStatus3.Items.Clear();

            cmbStatus3.Items.Add("");
            if (staType.Count > 0)
            {
                cmbStatus3.DataSource = staType;
                cmbStatus3.ValueMember = "Code";
                cmbStatus3.DisplayMember = "Descrip";
            }
            cmbStatus3.DropDownStyle = ComboBoxStyle.DropDownList;


            List<CodeTypeData> sexType = _setUpController.GetCodeTable(Utility.CodeTable.CodeSexType);

            cmbGender3.DataSource = null;
            cmbGender3.Items.Clear();

            cmbGender3.Items.Add("");
            if (staType.Count > 0)
            {
                cmbGender3.DataSource = sexType;
                cmbGender3.ValueMember = "Code";
                cmbGender3.DisplayMember = "Descrip";
            }
            cmbGender3.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void ClearInputFields()
        {
            // Clear input fields
            textfname2.Text = "";
            textLname2.Text = "";
            cmbStatus3.Text = "";
            cmbGender3.Text = "";
            textMname2.Text = "";
            textReason2.Text = "";
            textPhone2.Text = "";
            textMembershipNo2.Text = "";
            textDepartment2.Text = "";
            textEmail2.Text = "";
            lblReport.Text = "";


            cmbStatus3.SelectedIndex = -1;
            cmbGender3.SelectedIndex = -1;

            cmbStatus3.Update();
            cmbGender3.Update();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Control ctlr = this;
            string strError = null;
            if (string.IsNullOrWhiteSpace(textEmail2.Text))
            {
                ctlr = textEmail2;
                strError = "Please enter Email";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            var checkMember = _memberController.GetMemberByEmail(textEmail2.Text);
            if (checkMember == null || (checkMember.Status=="IAC"))
            {
                DisplayMessage("Member not found Or member is in-active, to add worker member must be active, kindly add or update member first with a valid member email!", MessageBoxIcon.Error);
                ClearInputFields();
                return;

            }

            textfname2.Text = checkMember.Firstname;
            textLname2.Text = checkMember.Lastname;

            // Find the description based on the status code
            var statusDescription = ((List<CodeTypeData>)cmbStatus3.DataSource)
                                    .FirstOrDefault(x => x.Code == checkMember.Status)?.Descrip;

            if (!string.IsNullOrEmpty(statusDescription))
            {
                cmbStatus3.SelectedIndex = cmbStatus3.FindStringExact(statusDescription);
            }
            else
            {
                cmbStatus3.SelectedIndex = -1; // or some default value if desired
            }


            var sexDescription = ((List<CodeTypeData>)cmbGender3.DataSource)
                                    .FirstOrDefault(x => x.Code == checkMember.Sex)?.Descrip;

            if (!string.IsNullOrEmpty(sexDescription))
            {
                cmbGender3.SelectedIndex = cmbGender3.FindStringExact(sexDescription);
            }
            else
            {
                cmbGender3.SelectedIndex = -1; // or some default value if desired
            }

            cmbStatus3.SelectedValue = checkMember.Status;
            cmbGender3.Text = checkMember.Sex;
            textMname2.Text = checkMember.Middlename;
            textReason2.Text = checkMember.Reason;
            textPhone2.Text = checkMember.PhoneNumber;
            textMembershipNo2.Text = checkMember.MembershipNo.ToString();
            textDepartment2.Text = checkMember.Department;
            textEmail2.Text = checkMember.Email;


            btnAddworker.Enabled = true;
            btnUpdate.Enabled = true;
            textDepartment2.Enabled = true;
            cmbStatus3.Enabled = true;
            cmbGender3.Enabled = true;
            textReason2.Enabled = true;
            lblReport.Text = "Member record found!";

            
        }
        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Worker", MessageBoxButtons.OK, icon);
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

        private async void btnAddworker_Click(object sender, EventArgs e)
        {
            _wor = new WorkerData();
            Control ctlr = this;
            string strError = null;



            if (string.IsNullOrWhiteSpace(textDepartment2.Text) || string.IsNullOrWhiteSpace(textLname2.Text) || string.IsNullOrWhiteSpace(textfname2.Text) || string.IsNullOrWhiteSpace(textMname2.Text))
            {
                ctlr = textDepartment2;

                strError = "Please Search Member record using member email, If Member record is found, kindly enter department to continue";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }


            var checkMember = _memberController.GetMemberByEmail(textEmail2.Text);
            if (checkMember == null || (checkMember.Status == "IAC")||checkMember.Status == "SUP" || checkMember.Status == "UKN" || checkMember.Status == "UNA" ||checkMember.Status == "DIS")
            {
                DisplayMessage("Member not found Or member is in-active, to add worker member must be active, kindly add or update member first with a valid member email!", MessageBoxIcon.Error);
                ClearInputFields();
                return;

            }


            var getWorker = _memberController.GetWorkerByEmail(textEmail2.Text);
            if (getWorker == null)
            {
                var getMemberRef = _memberController.GetMemberByEmail(textEmail2.Text);


                _wor.Firstname = textfname2.Text;
                _wor.Lastname = textLname2.Text;
                _wor.Status = cmbStatus3.Text;
                _wor.Sex = cmbGender3.Text;
                _wor.Middlename = textMname2.Text;
                _wor.Reason = textReason2.Text;
                _wor.PhoneNumber = textPhone2.Text;
                _wor.MembershipNo = textMembershipNo2.Text;
                _wor.Department = textDepartment2.Text;
                _wor.MemberRef = getMemberRef.MemberRef;
                _wor.Address = getMemberRef.Address;
                _wor.Email = textEmail2.Text;



                _wor.DateCreated = dateTimePicker3.Value.Date;
                _wor.DateAssigned = dateTimePicker5.Value.Date;


                bool saveResult = await _memberController.SaveWorker(_wor);

                if (saveResult)
                {
                    DisplayMessage("Worker added successfully!", MessageBoxIcon.Information);
                    ClearInputFields(); // Clear input fields after successful save
                    btnAddworker.Enabled = false;
                }
                else
                {
                    DisplayMessage("Error occurred while saving worker!", MessageBoxIcon.Error);
                }
            }

            if (getWorker != null && getWorker.Department != null)
            {
                DisplayMessage($"{getWorker.Firstname},{getWorker.Lastname} already belongs to {getWorker.Department} department! Kindly Update to add another department", MessageBoxIcon.Information);
                ClearInputFields(); // Clear input fields after successful save
                return;
            }


        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
           
            Control ctlr = this;
            string strError = null;
            if (string.IsNullOrWhiteSpace(textEmail2.Text))
            {
                ctlr = textEmail2;
                strError = "Please enter Email";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            var getWorker = _memberController.GetWorkerByEmail(textEmail2.Text);
            if (getWorker == null)
            {
                DisplayMessage("Worker not found, kindly input a valid worker email, or add worker to proceed!", MessageBoxIcon.Error);
                ClearInputFields(); // Clear input fields after successful save
                return;
            }

            var checkMemberStatus = _memberController.GetMemberByEmail(textEmail2.Text);
            if (checkMemberStatus == null)
            {
                DisplayMessage("Member not found Or member is in-active, to add worker member must be active, kindly add or update member first with a valid member email!", MessageBoxIcon.Error);
                ClearInputFields();
                return;

            }

            if (cmbStatus3.SelectedValue =="ACT" && checkMemberStatus.Status=="IAC")
            {
                DisplayMessage("Member must be active, kindly add or update member first with a valid member email!", MessageBoxIcon.Error);
                ClearInputFields();
                return;
            }


            getWorker.Firstname = textfname2.Text;
            getWorker.Lastname = textLname2.Text;
            getWorker.Status = cmbStatus3.Text;
            getWorker.Sex = cmbGender3.Text;
            getWorker.Middlename = textMname2.Text;
            getWorker.Reason = textReason2.Text;
            getWorker.PhoneNumber = textPhone2.Text;
            getWorker.Department = textDepartment2.Text;
            getWorker.Email = textEmail2.Text;
            //getWorker.DateCreated = getWorker.DateCreated;
            getWorker.DateAssigned = dateTimePicker5.Value.Date;
            getWorker.DateModified = dateTimePicker3.Value;
            getWorker.MemberRef=getWorker.MemberRef;
            getWorker.WorkerId = getWorker.WorkerId;
         

            bool updateResult = await _memberController.UpdateWorker(getWorker);
            if (updateResult)
            {
                DisplayMessage("Worker updated successfully!", MessageBoxIcon.Information);
                this.Close(); // Close the form after successful update
            }
            else
            {
                DisplayMessage("Error occurred while updating worker!", MessageBoxIcon.Error);
            }



        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

    
    
    }
}
