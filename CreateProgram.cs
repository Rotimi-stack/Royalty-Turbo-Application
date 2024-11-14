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
    public partial class CreateProgram : Form
    {
        
        private ProgramItenaryData _program;


        public readonly ISQL _db;
        private IMemberController _memberController;
        private CodeStatusType _statusType;
        private CodeSexType _sexType;
        private CodeNationalityType _nat;
        private CodeProgramStatusType _progStatus;
        private CodeStateType _state;
        private ISetUpController _setUpController;
        private bool _isEditMode;
        public CreateProgram(string connectionString, ProgramItenaryData program = null)
        {
           
            InitializeComponent();
            SetCurvedEdges();
            _program = program ?? new ProgramItenaryData(); // If no member is provided, create a new one
            _isEditMode = program != null;
            _memberController = new MemberController(connectionString);
            _progStatus = new CodeProgramStatusType();
            _setUpController = new SetUpController(connectionString);
            MakePanelCircular(panel4);
            LoadCodeTable2();
            

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
        protected void LoadCodeTable2()
        {


            List<CodeTypeData> proType = _setUpController.GetCodeTable(Utility.CodeTable.CodeProgramStatusType);

            cmbProgStatus.DataSource = null;
            cmbProgStatus.Items.Clear();

            cmbProgStatus.Items.Add("");
            if (proType.Count > 0)
            {
                cmbProgStatus.DataSource = proType;
                cmbProgStatus.ValueMember = "Code";
                cmbProgStatus.DisplayMember = "Descrip";
            }
            cmbProgStatus.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void ClearInputFields()
        {
            // Clear input fields
            textNameProg.Text = "";
            textTopic.Text = "";
            textText.Text = "";
            textMin.Text = "";

            cmbProgStatus.SelectedIndex = -1;


            textReason.Text = "";
            textGstMin.Text = "";
            textProgMin.Text = "";
            textTime.Text = "";

            cmbProgStatus.Update();
        }

        private void PopulateFields()
        {
            textNameProg.Text = _program.NameOfProgram;

            textProgMin.Text = _program.OtherOfficiatingMinisters;

            textMin.Text = _program.Minister;
            textText.Text = _program.Text;

            textTopic.Text = _program.Topic;

            

            

            textReason.Text = _program.Reason;

            textGstMin.Text = _program.GuestMinisters;

            

            textTime.Text = _program.TimeofProgram;

            cmbProgStatus.FindStringExact(_program.Status);

            dateProg.Value = _program.DateOfProgram;

           // dtpDate.Value = _program.DateCreated;

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

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private async void btnAddProg1_Click(object sender, EventArgs e)
        {
            if (!_isEditMode)
            {
                var getProg = _memberController.GetDedicationByName(textNameProg.Text);
                if (getProg != null)
                {
                    DisplayMessage("Program details already captured", MessageBoxIcon.Error);
                    ClearInputFields(); // Clear input fields after successful save
                    return;
                }
            }


            Control ctlr = this;
            string strError = null;


            _program.NameOfProgram = textNameProg.Text;
            _program.Topic = textTopic.Text;
            _program.Text = textText.Text;
            _program.Minister = textMin.Text;
            _program.Reason = textReason.Text;
            _program.GuestMinisters = textGstMin.Text;
            _program.OtherOfficiatingMinisters = textProgMin.Text;
            _program.TimeofProgram = textTime.Text;
            _program.Status = cmbProgStatus.Text;




            if (string.IsNullOrWhiteSpace(_program.NameOfProgram))
            {
                ctlr = textNameProg;
                strError = "Please enter Program Name";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.Topic))
            {
                ctlr = textTopic;
                strError = "Please enter Topic";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.Text))
            {
                ctlr = textText;
                strError = "Please enter Middlename";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.Text))
            {
                ctlr = textText;
                strError = "Please enter Middlename";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.Minister))
            {
                ctlr = textMin;
                strError = "Please enter Minister";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.Reason))
            {
                ctlr = textReason;
                strError = "Please enter Reason";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.GuestMinisters))
            {
                ctlr = textGstMin;
                strError = "Please enter GuestMinisters";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.OtherOfficiatingMinisters))
            {
                ctlr = textProgMin;
                strError = "Please enter Other Officiating Ministers";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(_program.TimeofProgram))
            {
                ctlr = textTime;
                strError = "Please enter Time of Program";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (cmbProgStatus.SelectedIndex != -1)
            {
                _program.Status = cmbProgStatus.SelectedValue.ToString();

            }

            else
            {
                ctlr = cmbProgStatus;
                strError = "Please enter Status";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;

            }




            _program.DateOfProgram = dateProg.Value.Date;
            _program.DateCreated = DateTime.Now;
            _program.DateModified = DateTime.Now;
            if (_isEditMode)
            {
                // Call the Update method in the MemberController
                bool updateResult = await _memberController.UpdateProgram(_program);

                if (updateResult)
                {
                    DisplayMessage("Program record updated successfully!", MessageBoxIcon.Information);
                    this.Close(); // Close the form after successful update
                }
                else
                {
                    DisplayMessage("Error occurred while updating program record!", MessageBoxIcon.Error);
                }
            }
            else
            {
                // Call the Save method in the MemberController
                bool saveResult = await _memberController.SaveProgram(_program);

                if (saveResult)
                {
                    DisplayMessage("Program added successfully!", MessageBoxIcon.Information);
                    ClearInputFields(); // Clear input fields after successful save
                }
                else
                {
                    DisplayMessage("Error occurred while saving Program!", MessageBoxIcon.Error);
                }
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
