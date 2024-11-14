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
    public partial class CreateAppointment : Form
    {
        private MemberData _mem;
        private AppointmentManagementData _app;
        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeStateType _state;
        private CodeAppointmentStatusType _appSta;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateAppointment(string connectionString, AppointmentManagementData appoint = null)
        {
            
            InitializeComponent();
            SetCurvedEdges();


            _app = appoint ?? new AppointmentManagementData(); // If no member is provided, create a new one
            _isEditMode = appoint != null;
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _appSta = new CodeAppointmentStatusType();
            _setUpController = new SetUpController(connectionString);
           
            ClearInputFields();
            MakePanelCircular(panel5);
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
        private void PopulateFields()
        {


            txtVisReason.Text = _app.Reason;
            txtPurpose.Text = _app.Purpose;
            texWhomToSee.Text = _app.WhomToSee;
            textVisName.Text = _app.VisitorName;
            txtAppointTime.Text = _app.AppointmentTime;
            textPhoneNo.Text= _app.PhoneNo;
            cmbVisSex.SelectedValue = _app.Sex;

            cmbVisStatus.SelectedIndex = cmbVisStatus.FindStringExact(_app.Status);
            //cmbVisSex.SelectedIndex = cmbVisSex.FindStringExact(_app.Sex);
            DateAppointment.Value = _app.AppointmentDate;

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
        private void ClearInputFields()
        {
            // Clear input fields
            txtVisReason.Text = "";
            txtPurpose.Text = "";
            texWhomToSee.Text = "";
            textVisName.Text = "";
            txtAppointTime.Text = "";
            textPhoneNo.Text = "";
            cmbVisStatus.Text = "";
            cmbVisSex.Text = "";






            cmbVisStatus.SelectedIndex = -1;
            cmbVisSex.SelectedIndex = -1;

            cmbVisStatus.Update();
            cmbVisSex.Update();

            DateAppointment.Value = DateTime.Now;




        }
        protected void LoadCodeTable()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeAppointmentStatusType);

            cmbVisStatus.DataSource = null;
            cmbVisStatus.Items.Clear();

            cmbVisStatus.Items.Add("");
            if (staType.Count > 0)
            {
                cmbVisStatus.DataSource = staType;
                cmbVisStatus.ValueMember = "Code";
                cmbVisStatus.DisplayMember = "Descrip";
            }
            cmbVisStatus.DropDownStyle = ComboBoxStyle.DropDownList;



            List<CodeTypeData> sex = _setUpController.GetCodeTable(Utility.CodeTable.CodeSexType);
            cmbVisSex.DataSource = null;
            cmbVisSex.Items.Clear();

            cmbVisSex.Items.Add("");

            if (sex.Count > 0)
            {


                cmbVisSex.DataSource = sex;
                cmbVisSex.ValueMember = "Code";
                cmbVisSex.DisplayMember = "Descrip";

            }
            cmbVisSex.DropDownStyle = ComboBoxStyle.DropDownList;

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
        private async void btnVisAppointmentAdd_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                var getWorker = _memberController.GetAppointmentByPhone(textPhoneNo.Text);
                if (getWorker != null)
                {
                    DisplayMessage("Worker details already captured", MessageBoxIcon.Error);
                    ClearInputFields(); // Clear input fields after successful save
                    return;
                }
            }


            Control ctlr = this;
            string strError = null;

            _app.Reason = txtVisReason.Text;
            _app.Purpose = txtPurpose.Text;
            _app.WhomToSee = texWhomToSee.Text;
            _app.VisitorName= textVisName.Text;
            _app.AppointmentTime = txtAppointTime.Text;
            _app.PhoneNo = textPhoneNo.Text;
            _app.Sex = cmbVisSex.Text;
            _app.Status = cmbVisStatus.Text;



          
            

            if (string.IsNullOrWhiteSpace(_app.PhoneNo))
            {
                ctlr = textPhoneNo;
                strError = "Please enter Phone";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(_app.Reason))
            {
                ctlr = txtVisReason;
                strError = "Please enter Reason";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_app.Purpose))
            {
                ctlr = txtPurpose;
                strError = "Please enter Purpose";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_app.WhomToSee))
            {
                ctlr = texWhomToSee;
                strError = "Please enter whom to see";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_app.VisitorName))
            {
                ctlr = textVisName;
                strError = "Please enter Address";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_app.AppointmentTime))
            {
                ctlr = txtAppointTime;
                strError = "Please enter Appointment time";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (cmbVisStatus.SelectedIndex != -1)
            {
                _app.Status = cmbVisStatus.SelectedValue.ToString();

            }

            else
            {
                ctlr = cmbVisStatus;
                strError = "Please enter Status";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;

            }

            if (cmbVisSex.SelectedIndex != -1)
            {
                _app.Sex = cmbVisSex.SelectedValue.ToString();

            }

            else
            {
                ctlr = cmbVisSex;
                strError = "Please enter Gender";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;

            }

          
            _app.AppointmentDate= DateAppointment.Value.Date;
            _app.DateCreated = DateTime.Now;
            _app.DateModified = DateTime.Now;
            if (_isEditMode)
            {
                // Call the Update method in the MemberController
                bool updateResult = await _memberController.UpdateAppointment(_app);

                if (updateResult)
                {
                    DisplayMessage("Appointment updated successfully!", MessageBoxIcon.Information);
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    DisplayMessage("Error occurred while updating Appointment!", MessageBoxIcon.Error);
                }
            }
            else
            {
                // Call the Save method in the MemberController
                bool saveResult = await _memberController.SaveAppointment(_app);

                if (saveResult)
                {
                    DisplayMessage("Appointment added successfully!", MessageBoxIcon.Information);
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
    

