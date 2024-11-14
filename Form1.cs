using Microsoft.Reporting.WinForms;
using Royalty_Turbo.Common.Data;
using Royalty_Turbo.Controller;
using Royalty_Turbo.DataAccess.Desktop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Royalty_Turbo
{
    public partial class Form1 : Form
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
        private CodeAppointmentStatusType _aps;
        private CodeStateType _state;
        private CodeMarriageStatusType _status;
        private CodeProgramStatusType _progStatus;
        private ISetUpController _setUpController;
        #endregion
        private string _connectionString;
        private float fontSize = 12f;
        public Form1(string connectionString)
        {

            InitializeComponent();

            ListView_Settings();
            ListView_Settings2();
            SetDoubleBuffered(listView1);
            _connectionString = connectionString;
            _mem = new MemberData();
            _memberController = new MemberController(connectionString);
            _statusType = new CodeStatusType();
            _sexType = new CodeSexType();
            _nat = new CodeNationalityType();
            _state = new CodeStateType();
            _status = new CodeMarriageStatusType();
            _progStatus = new CodeProgramStatusType();
            _aps = new CodeAppointmentStatusType();
            _setUpController = new SetUpController(connectionString);
            LoadCodeTable();
            LoadCodeTable2();
            PerformSearchAndUpdateLabels();
            MakePanelCircular(panel7);

            Updates.DrawMode = DrawMode.OwnerDrawVariable;
            Updates.MeasureItem += Updates_MeasureItem;
            Updates.DrawItem += Updates_DrawItem;


            ClearInputFields();


        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void Updates_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item text
            string itemText = Updates.Items[e.Index].ToString();

            // Measure the size of the text with the specified font size
            using (Font font = new Font(Updates.Font.FontFamily, fontSize))
            {
                SizeF textSize = e.Graphics.MeasureString(itemText, font, Updates.Width);
                e.ItemHeight = (int)textSize.Height;
            }
        }

        private void Updates_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Get the item text
            string itemText = Updates.Items[e.Index].ToString();

            // Draw the background
            e.DrawBackground();

            // Draw the text with the specified font size
            using (Font font = new Font(Updates.Font.FontFamily, fontSize))
            {
                e.Graphics.DrawString(itemText, font, Brushes.Black, e.Bounds);
            }

            // Draw the focus rectangle if the item has focus
            e.DrawFocusRectangle();
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
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeStatusType);

            cmbStatus2.DataSource = null;
            cmbStatus2.Items.Clear();

            cmbStatus2.Items.Add("");
            if (staType.Count > 0)
            {
                cmbStatus2.DataSource = staType;
                cmbStatus2.ValueMember = "Code";
                cmbStatus2.DisplayMember = "Descrip";
            }
            cmbStatus2.DropDownStyle = ComboBoxStyle.DropDownList;


            List<CodeTypeData> sex = _setUpController.GetCodeTable(Utility.CodeTable.CodeSexType);
            cmbGender1.DataSource = null;
            cmbGender1.Items.Clear();

            cmbGender1.Items.Add("");

            if (sex.Count > 0)
            {


                cmbGender1.DataSource = sex;
                cmbGender1.ValueMember = "Code";
                cmbGender1.DisplayMember = "Descrip";

            }
            cmbGender1.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        protected void LoadCodeTable2()
        {
            List<CodeTypeData> staType = _setUpController.GetCodeTable(Utility.CodeTable.CodeStatusType);

            cmbWorkStatus.DataSource = null;
            cmbWorkStatus.Items.Clear();

            cmbWorkStatus.Items.Add("");
            if (staType.Count > 0)
            {
                cmbWorkStatus.DataSource = staType;
                cmbWorkStatus.ValueMember = "Code";
                cmbWorkStatus.DisplayMember = "Descrip";
            }
            cmbWorkStatus.DropDownStyle = ComboBoxStyle.DropDownList;


            List<CodeTypeData> proType = _setUpController.GetCodeTable(Utility.CodeTable.CodeProgramStatusType);

            comboStatus.DataSource = null;
            comboStatus.Items.Clear();

            comboStatus.Items.Add("");
            if (proType.Count > 0)
            {
                comboStatus.DataSource = proType;
                comboStatus.ValueMember = "Code";
                comboStatus.DisplayMember = "Descrip";
            }
            comboStatus.DropDownStyle = ComboBoxStyle.DropDownList;


            List<CodeTypeData> sex = _setUpController.GetCodeTable(Utility.CodeTable.CodeSexType);
            cmbGenderWorker.DataSource = null;
            cmbGenderWorker.Items.Clear();

            cmbGenderWorker.Items.Add("");

            if (sex.Count > 0)
            {


                cmbGenderWorker.DataSource = sex;
                cmbGenderWorker.ValueMember = "Code";
                cmbGenderWorker.DisplayMember = "Descrip";

            }
            cmbGenderWorker.DropDownStyle = ComboBoxStyle.DropDownList;


            List<CodeTypeData> equType = _setUpController.GetCodeTable(Utility.CodeTable.CodeEquipmentStatusType);

            cmbStaEqu.DataSource = null;
            cmbStaEqu.Items.Clear();

            cmbStaEqu.Items.Add("");
            if (equType.Count > 0)
            {
                cmbStaEqu.DataSource = equType;
                cmbStaEqu.ValueMember = "Code";
                cmbStaEqu.DisplayMember = "Descrip";
            }
            cmbStaEqu.DropDownStyle = ComboBoxStyle.DropDownList;

            List<CodeTypeData> marType = _setUpController.GetCodeTable(Utility.CodeTable.CodeMarriageStatusType);

            cmbMarriageStatus.DataSource = null;
            cmbMarriageStatus.Items.Clear();

            cmbMarriageStatus.Items.Add("");
            if (marType.Count > 0)
            {
                cmbMarriageStatus.DataSource = marType;
                cmbMarriageStatus.ValueMember = "Code";
                cmbMarriageStatus.DisplayMember = "Descrip";
            }
            cmbMarriageStatus.DropDownStyle = ComboBoxStyle.DropDownList;



            List<CodeTypeData> visType = _setUpController.GetCodeTable(Utility.CodeTable.CodeAppointmentStatusType);

            cmbAppointStatus.DataSource = null;
            cmbAppointStatus.Items.Clear();

            cmbAppointStatus.Items.Add("");
            if (visType.Count > 0)
            {
                cmbAppointStatus.DataSource = visType;
                cmbAppointStatus.ValueMember = "Code";
                cmbAppointStatus.DisplayMember = "Descrip";
            }
            cmbAppointStatus.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        private void ListView_Settings()
        {

            // Setup ListView


            listView1.Items.Clear();
            listView1.Columns.Add("Membership Ref", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Firstname", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Lastname", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Middlename", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("PhoneNo", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Address", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Occupation", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Nationality", 90, HorizontalAlignment.Left);
            listView1.Columns.Add("State", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Department", 150, HorizontalAlignment.Left); // Move this before Reason
            listView1.Columns.Add("Reason", 150, HorizontalAlignment.Left); // Move this after Department
            listView1.Columns.Add("Status", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Status Code", 50, HorizontalAlignment.Left); // New column
            listView1.Columns.Add("Gender", 60, HorizontalAlignment.Left); // Assuming Gender column
            listView1.Columns.Add("Created At", 60, HorizontalAlignment.Left);
            listView1.Columns.Add("Modified At", 60, HorizontalAlignment.Left);

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            foreach (ListViewItem item in listView1.Items)
            {
                item.UseItemStyleForSubItems = false;
            }



        }
        private void ListView_Settings2()
        {

            listView2.Items.Clear();
            listView2.Columns.Add("Member Ref", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Firstname", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Lastname", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Middlename", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("PhoneNo", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Address", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("MembershipNo", 60, HorizontalAlignment.Left);
            listView2.Columns.Add("Department", 150, HorizontalAlignment.Left); // Move this before Reason
            listView2.Columns.Add("Reason", 150, HorizontalAlignment.Left); // Move this after Department
            listView2.Columns.Add("Status", 60, HorizontalAlignment.Left);
            listView2.Columns.Add("Status Code", 60, HorizontalAlignment.Left);
            listView2.Columns.Add("Gender", 60, HorizontalAlignment.Left); // Assuming Gender column
            listView2.Columns.Add("Created At", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Modified At", 150, HorizontalAlignment.Left);




            listView2.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;



            listView4.Items.Clear();
            listView4.Columns.Add("Equipment Id", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("EquipmentName", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("Brand", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("Quantity", 60, HorizontalAlignment.Left);
            listView4.Columns.Add("Purchase Price", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("Status", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("Status Code", 50, HorizontalAlignment.Left);
            listView4.Columns.Add("Purchased Date", 150, HorizontalAlignment.Left); // Assuming Gender column
            listView4.Columns.Add("Created At", 150, HorizontalAlignment.Left);
            listView4.Columns.Add("Modified At", 150, HorizontalAlignment.Left);

            listView4.View = View.Details;
            listView4.GridLines = true;
            listView4.FullRowSelect = true;








            listView5.Items.Clear();
            listView5.Columns.Add("Marriage Id", 200, HorizontalAlignment.Left);
            listView5.Columns.Add("CoupleName", 200, HorizontalAlignment.Left);
            listView5.Columns.Add("CertificateName", 200, HorizontalAlignment.Left);
            listView5.Columns.Add("Status", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("Status Code", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("Reason", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("Officials", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("ScheduledDate", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("Created At", 150, HorizontalAlignment.Left);
            listView5.Columns.Add("Modified At", 150, HorizontalAlignment.Left);

            listView5.View = View.Details;
            listView5.GridLines = true;
            listView5.FullRowSelect = true;


            listView6.Items.Clear();
            listView6.Columns.Add("Dedication Id", 60, HorizontalAlignment.Left);
            listView6.Columns.Add("Name", 200, HorizontalAlignment.Left);
            listView6.Columns.Add("CertificateName", 200, HorizontalAlignment.Left);
            listView6.Columns.Add("Officiating Ministers", 200, HorizontalAlignment.Left);
            listView6.Columns.Add("dedication Date", 200, HorizontalAlignment.Left);
            listView6.Columns.Add("Created At", 200, HorizontalAlignment.Left);
            listView6.Columns.Add("Modified At", 200, HorizontalAlignment.Left);

            listView6.View = View.Details;
            listView6.GridLines = true;
            listView6.FullRowSelect = true;




            listView7.Items.Clear();
            listView7.Columns.Add("Program Id", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Program Name", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Topic", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Text", 150, HorizontalAlignment.Left);
            listView7.Columns.Add("Reason", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Status", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Status Code", 50, HorizontalAlignment.Left);
            listView7.Columns.Add("Minister", 150, HorizontalAlignment.Left);
            listView7.Columns.Add("GuestMinisters", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Officiating Ministers", 80, HorizontalAlignment.Left);
            listView7.Columns.Add("Time of Program", 150, HorizontalAlignment.Left);
            listView7.Columns.Add("Program Date", 60, HorizontalAlignment.Left);
            listView7.Columns.Add("Date Created", 60, HorizontalAlignment.Left);
            listView7.Columns.Add("Date Modified", 60, HorizontalAlignment.Left);

            listView7.View = View.Details;
            listView7.GridLines = true;
            listView7.FullRowSelect = true;



            listView3.Items.Clear();
            listView3.Columns.Add("VisitorName", 150, HorizontalAlignment.Left);
            listView3.Columns.Add("Sex", 80, HorizontalAlignment.Left);
            listView3.Columns.Add("Phone No", 150, HorizontalAlignment.Left);
            listView3.Columns.Add("Whom To See", 100, HorizontalAlignment.Left);
            listView3.Columns.Add("Purpose", 100, HorizontalAlignment.Left);
            listView3.Columns.Add("Status", 150, HorizontalAlignment.Left);
            listView3.Columns.Add("Status Code", 50, HorizontalAlignment.Left);
            listView3.Columns.Add("Reason", 80, HorizontalAlignment.Left);
            listView3.Columns.Add("Time Of Appointment", 80, HorizontalAlignment.Left);
            listView3.Columns.Add("Appointment Date", 60, HorizontalAlignment.Left);
            listView3.Columns.Add("Date Created", 60, HorizontalAlignment.Left);
            listView3.Columns.Add("Date Modified", 60, HorizontalAlignment.Left);

            listView3.View = View.Details;
            listView3.GridLines = true;
            listView3.FullRowSelect = true;

        }

        // Drawing handlers
        // Enable double buffering for the ListView
        private void SetDoubleBuffered(Control control)
        {
            System.Reflection.PropertyInfo doubleBufferPropertyInfo = control.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (doubleBufferPropertyInfo != null)
            {
                doubleBufferPropertyInfo.SetValue(control, true, null);
            }
        }
        private void ClearInputFields()
        {
            dateTimeFrom.Value = dateTimeFrom.MinDate;
            dateTimeFrom.MinDate = new DateTime(2000, 1, 1);


            dateTimeTo.Value = DateTime.Now;


            dtpWorkFrom.Value = dtpWorkFrom.MinDate;
            dtpWorkFrom.MinDate = new DateTime(2000, 1, 1);
            dtpWorkTo.Value = DateTime.Now;

            dtpEqpfrom.Value = dtpEqpfrom.MinDate;
            dtpEqpfrom.MinDate = new DateTime(2000, 1, 1);
            dtpEqpTo.Value = DateTime.Now;


            dtpProgFrom.Value = dtpProgFrom.MinDate;
            dtpProgFrom.MinDate = new DateTime(2000, 1, 1);


            dtpProgTo.Value = DateTime.Now;



            dtpAppointmentFrom.Value = dtpAppointmentFrom.MinDate;
            dtpAppointmentFrom.MinDate = new DateTime(2000, 1, 1);

            dtpAppointmentTo.Value = DateTime.Now;




            cmbAppointStatus.SelectedValue = -1;
            cmbAppointStatus.Update();

            comboStatus.SelectedValue = -1;
            comboStatus.Update();

            ResetDatePicker(dateTimePicker4);
            ResetDatePicker(dateTimePicker3);
            ResetDatePicker(dtpScheduledFrom);
            ResetDatePicker(dtpScheduledTo);

            //ResetDatePicker(dtpAppointDateFrom);
            //ResetDatePicker(dtpAppointmentDateTo);
            //ResetDatePicker(dtpAppointDateTo);
            //ResetDatePicker(dtpAppointDate);



            cmbGenderWorker.SelectedValue = -1;
            cmbWorkStatus.SelectedValue = -1;


            cmbGender1.SelectedIndex = -1;
            cmbStatus2.SelectedIndex = -1;

            textFirstname.Text = "";
            textLastname.Text = "";
            textDept.Text = "";
            txtOccupation.Text = "";

            cmbGender1.Update();
            cmbStatus2.Update();
            textFirstname.Update();
            textLastname.Update();
            textDept.Update();
            txtOccupation.Update();


            txtWokFname.Text = "";
            txtWorkLname.Text = "";
            txtWorkDept.Text = "";
            cmbGenderWorker.Text = "";
            cmbWorkStatus.Text = "";

            txtWokFname.Update();
            txtWorkLname.Update();
            txtWorkDept.Update();
            cmbGenderWorker.Update();
            cmbWorkStatus.Update();


            texteqpName.Text = "";
            textBrand.Text = "";
            cmbStaEqu.Text = "";

            cmbStaEqu.SelectedIndex = -1;

            cmbStaEqu.Update();


            txtCoupName.Text = "";
            cmbMarriageStatus.Text = "";

            dtpScheduledFrom.Value = dtpScheduledFrom.MinDate;
            dtpScheduledFrom.MinDate = new DateTime(2000, 1, 1);

            dtpScheduledTo.Value = DateTime.Now;



            cmbMarriageStatus.SelectedIndex = -1;
            cmbMarriageStatus.Update();

            dateTimePicker4.Value = dateTimePicker4.MinDate;
            dateTimePicker4.MinDate = new DateTime(2000, 1, 1);
            dateTimePicker3.Value = DateTime.Now;

            textName.Text = "";
            dtpDedicationFrom.Value = dtpDedicationFrom.MinDate;
            dtpDedicationFrom.MinDate = new DateTime(2000, 1, 1);

            dtpDedicationTo.Value = DateTime.Now;

            textProgName.Text = "";
            textMinister.Text = "";
            comboStatus.Text = "";
            comboStatus.Update();


        }
        private void ResetDatePicker(DateTimePicker datePicker)
        {
            datePicker.CustomFormat = " ";
            datePicker.Format = DateTimePickerFormat.Custom;
            datePicker.Value = DateTimePickerFormat.Short == datePicker.Format ? DateTime.Now : datePicker.MinDate;
            datePicker.Format = DateTimePickerFormat.Short;
        }
        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            dateTimeFrom.CustomFormat = "yyyy-MM-dd";
            dateTimeFrom.Format = DateTimePickerFormat.Custom;

        }
        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            dateTimeTo.CustomFormat = "yyyy-MM-dd";
            dateTimeTo.Format = DateTimePickerFormat.Custom;
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
        private void PerformSearchAndUpdateLabels()
        {
            // Search for members
            List<MemberData> memberSearchList = _memberController.Search(_strFilter, _strSort);
            int totalMembersCount = memberSearchList.Count;
            int activeMemberCount = memberSearchList.Count(item => item.StatusDescrip == "Active");
            lblActiveMembers.Text = $"{activeMemberCount}";



            int InactiveMemberCount = memberSearchList.Count(item => item.StatusDescrip == "In-Active");
            lblInActiveMembers.Text = $"{InactiveMemberCount}";

            int suspendedMemberCount = memberSearchList.Count(item => item.StatusDescrip == "Suspended");
            lblSuspended.Text = $"{suspendedMemberCount}";

            int unavailableMemberCount = memberSearchList.Count(item => item.StatusDescrip == "Unavailable");
            lblUnavailable.Text = $"{unavailableMemberCount}";

            // Update member labels
            lblTotalMembers.Text = $"{memberSearchList.Count}";
            lblTot.Text = $"{memberSearchList.Count}";
            lblMemTotal.Text = $"{memberSearchList.Count}";
            lblTotalMem.Text = $"{memberSearchList.Count}";
            lblMemTotal.Text = $"{memberSearchList.Count}";



            // Search for workers (if you have a separate search for workers)
            List<WorkerData> workerSearchList = _memberController.SearchWorker(_strFilter, _strSort);
            lblWorker.Text = $"{workerSearchList.Count}";




            // Count the number of active members
            int activeWorkerCount = workerSearchList.Count(item => item.StatusDescrip == "Active");
            lblActiveWorkers.Text = $"{activeWorkerCount}";

            int InactiveWorkerCount = workerSearchList.Count(item => item.StatusDescrip == "In-Active");
            lblInActiveWorkers.Text = $"{InactiveWorkerCount}";

            int suspendedWorkerCount = workerSearchList.Count(item => item.StatusDescrip == "Suspended");
            lblSuspendedWorkers.Text = $"{suspendedWorkerCount}";

        }






        //*********************************MEMBER**************************************

        #region Member
        private void btnAddMember_Click(object sender, System.EventArgs e)
        {
            CreateMember exp = new CreateMember(_connectionString);
            exp.ShowDialog();
        }


        private bool DisplayMemberSearchResult(List<MemberData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (MemberData member in searchList)
            {

                ListViewItem listViewItem = new ListViewItem(member.MemberRef);
                listViewItem.SubItems.Add(member.Firstname);
                listViewItem.SubItems.Add(member.Lastname);
                listViewItem.SubItems.Add(member.Middlename);
                listViewItem.SubItems.Add(member.PhoneNumber);
                listViewItem.SubItems.Add(member.Address);
                listViewItem.SubItems.Add(member.Email);
                listViewItem.SubItems.Add(member.Occupation);
                listViewItem.SubItems.Add(member.CountryDescrip);
                listViewItem.SubItems.Add(member.StateDescrip);

                listViewItem.SubItems.Add(member.Department);
                listViewItem.SubItems.Add(member.Reason);

                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, member.StatusDescrip);
                SetStatusTextColor(statusSubItem, member.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetStatusColorCode(colorCodeSubItem, member.StatusDescrip); // Set color code based on status
                listViewItem.SubItems.Add(colorCodeSubItem);

                listViewItem.SubItems.Add(member.Sex);
                listViewItem.SubItems.Add(member.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(member.DateModified.ToString("yyyy-MM-dd"));

                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling
                listView1.Items.Add(listViewItem);
            }

            return true;
        }

        private void SetStatusTextColor(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip?.ToLower())
            {
                case "active":
                    subItem.ForeColor = Color.Green;
                    break;
                case "in-active":
                case "unavailable":
                    subItem.ForeColor = Color.Orange;
                    break;
                case "dismissed":
                case "suspended":
                case "unknown":
                    subItem.ForeColor = Color.Red;
                    break;
                default:
                    subItem.ForeColor = listView1.ForeColor; // Default color if no match
                    break;
            }
        }

        private void SetStatusColorCode(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip?.ToLower())
            {
                case "active":
                    subItem.BackColor = Color.Green;
                    break;
                case "in-active":
                case "unavailable":
                    subItem.BackColor = Color.Orange;
                    break;
                case "dismissed":
                case "suspended":
                case "unknown":
                    subItem.BackColor = Color.Red;
                    break;
                default:
                    subItem.BackColor = Color.White; // Default background color if no match
                    break;
            }
        }


        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            listView1.Items.Clear();
            BuildSelect();
            List<MemberData> searchList = _memberController.Search(_strFilter, _strSort);
            if (searchList.Count > 0)
            {
                DisplayMemberSearchResult(searchList);
                decimal totalMemberNo = searchList.Sum(item => item.MemberId);


                lblTotal.Text = $"Total Amount is:{totalMemberNo.ToString("N")}";
                lblReport.Text = $"Number of Members found is: {searchList.Count}";
                lblTotalMembers.Text = $"{searchList.Count}";
                lblTot.Text = $"{searchList.Count}";
                lblMemTotal.Text = $"{searchList.Count}";
                lblTotalMem.Text = $"{searchList.Count}";
                lblMemTotal.Text = $"{searchList.Count}";


                // Count the number of active members
                int activeMemberCount = searchList.Count(item => item.StatusDescrip == "Active");
                lblActiveMembers.Text = $"{activeMemberCount}";



                int InactiveMemberCount = searchList.Count(item => item.StatusDescrip == "In-Active");
                lblInActiveMembers.Text = $"{InactiveMemberCount}";

                int suspendedMemberCount = searchList.Count(item => item.StatusDescrip == "Suspended");
                lblSuspended.Text = $"{suspendedMemberCount}";

                int unavailableMemberCount = searchList.Count(item => item.StatusDescrip == "Unavailable");
                lblUnavailable.Text = $"{unavailableMemberCount}";



                ClearInputFields();




            }
            else
            {
                lblReport.Text = "No Members matching specified criterion found!";

                lblTotal.Text = "Total Amount is:0.00";
                ClearInputFields();
            }
        }


        string _strFilter = "";
        string _strSort;
        private void BuildSelect()
        {
            string sex = Convert.ToString(cmbGender1.SelectedValue);
            string status = Convert.ToString(cmbStatus2.SelectedValue);
            string firstname = textFirstname.Text;
            string lastname = textLastname.Text;
            string department = textDept.Text;
            string occupation = txtOccupation.Text;

            List<string> conditions = new List<string>();

            if (dateTimeFrom.CustomFormat != " " && dateTimeTo.CustomFormat != " ")
            {
                DateTime dtFrom = dateTimeFrom.Value.Date;
                DateTime dtTo = dateTimeTo.Value.Date;
                conditions.Add(string.Format("DateCreated BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", dtFrom, dtTo));
            }

            if (!string.IsNullOrEmpty(sex))
            {
                conditions.Add(string.Format("sex LIKE '%{0}%'", sex));
            }
            if (!string.IsNullOrEmpty(status))
            {
                conditions.Add(string.Format("status LIKE '%{0}%'", status));
            }
            if (!string.IsNullOrEmpty(firstname))
            {
                conditions.Add(string.Format("firstname LIKE '%{0}%'", firstname));
            }
            if (!string.IsNullOrEmpty(lastname))
            {
                conditions.Add(string.Format("lastname LIKE '%{0}%'", lastname));
            }
            if (!string.IsNullOrEmpty(department))
            {
                conditions.Add(string.Format("department LIKE '%{0}%'", department));
            }
            if (!string.IsNullOrEmpty(occupation))
            {
                conditions.Add(string.Format("occupation LIKE '%{0}%'", occupation));
            }

            _strFilter = string.Join(" AND ", conditions);
            _strSort = "sex,status,firstname,lastname,department,occupation,DateCreated";
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                MemberData selectedMember = new MemberData()
                {
                    Firstname = selectedItem.SubItems[0].Text,
                    Lastname = selectedItem.SubItems[1].Text,
                    Middlename = selectedItem.SubItems[2].Text,
                    PhoneNumber = selectedItem.SubItems[3].Text,
                    Address = selectedItem.SubItems[4].Text,
                    Email = selectedItem.SubItems[5].Text,
                    Occupation = selectedItem.SubItems[6].Text,
                    Nationality = selectedItem.SubItems[7].Text,
                    State = selectedItem.SubItems[8].Text,
                    MembershipNo = Convert.ToInt32(selectedItem.SubItems[9].Text),
                    Department = selectedItem.SubItems[10].Text,
                    Reason = selectedItem.SubItems[11].Text,
                    Status = selectedItem.SubItems[12].Text,
                    Sex = selectedItem.SubItems[14].Text,
                    DateCreated = DateTime.Parse(selectedItem.SubItems[15].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[16].Text),

                };



                CreateMember createMemberForm = new CreateMember(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Member record selected. Please perform a search and select a member record to update.", MessageBoxIcon.Information);
            }

        }

        private void btnMemberPrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<MemberData> members = new List<MemberData>();
            foreach (ListViewItem item in listView1.Items)
            {
                MemberData member = new MemberData()
                {
                    MemberRef = item.SubItems[0].Text,
                    Firstname = item.SubItems[1].Text,      // Firstname column
                    Lastname = item.SubItems[2].Text,       // Lastname column
                    Middlename = item.SubItems[3].Text,     // Middlename column
                    PhoneNumber = item.SubItems[4].Text,    // PhoneNo column
                    Address = item.SubItems[5].Text,        // Address column
                    Email = item.SubItems[6].Text,          // Email column
                    Occupation = item.SubItems[7].Text,     // Occupation column
                                                            // Assuming "MemberRef" is equivalent to MembershipNo; if not, adjust accordingly
                                                            // MembershipNo column
                    Department = item.SubItems[10].Text,    // Department column
                    Status = item.SubItems[12].Text, // Status column
                    Sex = item.SubItems[14].Text            // Gender column

                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Member Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "MemberReport1.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }

        #endregion




        //******************************WORKER*****************************************


        #region Worker
        private bool DisplayWorkerSearchResult(List<WorkerData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (WorkerData member in searchList)
            {
                //Note the items here must be arranged accordingly to how it is coming from the db, so that it does not take a value of a column and put it in another column
                ListViewItem listViewItem = new ListViewItem(member.MemberRef);
                listViewItem.SubItems.Add(member.Firstname);
                listViewItem.SubItems.Add(member.Lastname);
                listViewItem.SubItems.Add(member.Middlename);
                listViewItem.SubItems.Add(member.PhoneNumber);
                listViewItem.SubItems.Add(member.Address);
                listViewItem.SubItems.Add(member.Email);
                listViewItem.SubItems.Add(member.MembershipNo.ToString());
                listViewItem.SubItems.Add(member.Department); // Move Department before Reason
                listViewItem.SubItems.Add(member.Reason); // Move Reason after Department


                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, member.StatusDescrip);
                SetStatusTextColor(statusSubItem, member.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetStatusColorCode(colorCodeSubItem, member.StatusDescrip); // Set color code based on status
                listViewItem.SubItems.Add(colorCodeSubItem);

                //listViewItem.SubItems.Add(member.StatusDescrip);
                listViewItem.SubItems.Add(member.Sex); // Assuming Gender
                listViewItem.SubItems.Add(member.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(member.DateModified.ToString("yyyy-MM-dd"));


                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling
                listView2.Items.Add(listViewItem);
            }


            return true;
        }

        private void btnWorker_Click(object sender, EventArgs e)
        {
            CreateWorker exp = new CreateWorker(_connectionString);
            exp.ShowDialog();
        }

        private void btnWorkSearch_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            BuildSelect2();
            List<WorkerData> searchList = _memberController.SearchWorker(_strFilter1, _strSort1);
            if (searchList.Count > 0)
            {
                DisplayWorkerSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.WorkerId);


                lblTotal.Text = $"Total Amount is:{totalWorkerNo.ToString("N")}";
                lblWorkerReport.Text = $"Number of Workers found is: {searchList.Count}";
                lblWorker.Text = $"{searchList.Count}";




                // Count the number of active members
                int activeWorkerCount = searchList.Count(item => item.StatusDescrip == "Active");
                lblActiveWorkers.Text = $"{activeWorkerCount}";

                int InactiveWorkerCount = searchList.Count(item => item.StatusDescrip == "In-Active");
                lblInActiveWorkers.Text = $"{InactiveWorkerCount}";

                int suspendedWorkerCount = searchList.Count(item => item.StatusDescrip == "Suspended");
                lblSuspendedWorkers.Text = $"{suspendedWorkerCount}";

                ClearInputFields();


            }
            else
            {
                lblWorkerReport.Text = "No Workers found!";

                lblTotal.Text = "Total Amount is:0.00";
                ClearInputFields();
            }
        }

        string _strFilter1 = "";
        string _strSort1;
        private void BuildSelect2()
        {
            //string sex = Convert.ToString(cmbGenderWorker.SelectedValue);
            string sex = cmbGenderWorker.Text;
            string status = Convert.ToString(cmbWorkStatus.SelectedValue);
            string firstname = txtWokFname.Text;
            string lastname = txtWorkLname.Text;
            string department = txtWorkDept.Text;

            string strWhere = "";
            _strFilter1 = "";
            _strSort1 = "sex,status,firstname,lastname,department";

            if (dtpWorkFrom.CustomFormat != " " && dtpWorkTo.CustomFormat != " ")
            {
                DateTime dtFrom = this.dtpWorkFrom.Value.Date;
                DateTime dtTo = this.dtpWorkTo.Value.Date;

                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere += "(";

                _strFilter1 = string.Format("DateCreated BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", dtFrom, dtTo);
                strWhere += _strFilter1 + ")";
            }


            if (!string.IsNullOrEmpty(sex))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("sex = '{0}' ", sex);
                strWhere += _strFilter1 + ")";
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("status LIKE '%{0}%' ", status);
                strWhere += _strFilter1 + ")";
            }
            if (!string.IsNullOrEmpty(firstname))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("firstname LIKE '%{0}%' ", firstname);
                strWhere += _strFilter1 + ")";
            }
            if (!string.IsNullOrEmpty(lastname))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("lastname  LIKE '%{0}%' ", lastname); // Append to the existing filter
                strWhere += _strFilter1 + ")";
            }
            if (!string.IsNullOrEmpty(department))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("department  LIKE '%{0}%' ", department); // Append to the existing filter
                strWhere += _strFilter1 + ")";
            }

            if (strWhere.Length > 0)
                _strFilter1 = strWhere;
        }

        private void btnUpdateWorker_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                MemberData selectedMember = new MemberData()
                {
                    Firstname = selectedItem.SubItems[0].Text,
                    Lastname = selectedItem.SubItems[1].Text,
                    Middlename = selectedItem.SubItems[2].Text,
                    PhoneNumber = selectedItem.SubItems[3].Text,
                    Address = selectedItem.SubItems[4].Text,
                    Email = selectedItem.SubItems[5].Text,
                    Occupation = selectedItem.SubItems[6].Text,
                    Nationality = selectedItem.SubItems[7].Text,
                    State = selectedItem.SubItems[8].Text,
                    MembershipNo = Convert.ToInt32(selectedItem.SubItems[9].Text),
                    Department = selectedItem.SubItems[10].Text,
                    Reason = selectedItem.SubItems[11].Text,
                    Status = selectedItem.SubItems[12].Text,
                    Sex = selectedItem.SubItems[13].Text,
                    DateCreated = DateTime.Parse(selectedItem.SubItems[14].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[15].Text),
                    // Make sure to populate other properties based on ListView columns
                };

                CreateMember createMemberForm = new CreateMember(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Member record selected. Please perform a search and select a member record to update.", MessageBoxIcon.Information);
            }
        }


        private void btnWorkerPrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<WorkerData> members = new List<WorkerData>();
            foreach (ListViewItem item in listView2.Items)
            {
                WorkerData member = new WorkerData()
                {
                    MemberRef = item.SubItems[0].Text,
                    Firstname = item.SubItems[1].Text,      // Firstname column
                    Lastname = item.SubItems[2].Text,       // Lastname column
                    Middlename = item.SubItems[3].Text,     // Middlename column
                    PhoneNumber = item.SubItems[4].Text,    // PhoneNo column
                    Address = item.SubItems[5].Text,        // Address column
                    Email = item.SubItems[6].Text,          // Email column

                   
                    Department = item.SubItems[8].Text,    // Department column
                    Reason = item.SubItems[9].Text,
                    Status = item.SubItems[10].Text, // Status column
                    Sex = item.SubItems[12].Text            // Gender column

                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Worker Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "WorkerReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet2", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }


        #endregion

        //************************************EQUIPMENT********************************************************


        #region Equipment
        private void btnAddEquipment_Click(object sender, EventArgs e)
        {
            CreateEquipment exp = new CreateEquipment(_connectionString);
            exp.ShowDialog();
        }
        private bool DisplayEquipmentSearchResult(List<EquipmentData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (EquipmentData member in searchList)
            {
                ListViewItem listViewItem = new ListViewItem(member.EquipmentId.ToString());
                listViewItem.SubItems.Add(member.EquipmentName);
                listViewItem.SubItems.Add(member.Brand);
                listViewItem.SubItems.Add(member.Quantity.ToString());
                listViewItem.SubItems.Add(member.PurchasePrice.ToString());

                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, member.StatusDescrip);
                SetEquipStatusTextColor(statusSubItem, member.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetEquipStatusColorCode(colorCodeSubItem, member.StatusDescrip); // Set color code based on status
                listViewItem.SubItems.Add(colorCodeSubItem);

                listViewItem.SubItems.Add(member.PurchasedDate.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(member.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(member.DateModified.ToString("yyyy-MM-dd"));

                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling
                listView4.Items.Add(listViewItem);
            }

            return true;
        }

        private void SetEquipStatusTextColor(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Good":
                case "In-Use":
                    subItem.ForeColor = Color.Green;
                    break;
                case "Borrowed":
                case "Unavailable":
                    subItem.ForeColor = Color.Orange;
                    break;
                case "Damaged":
                case "In-Repair":
                    subItem.ForeColor = Color.Red;
                    break;
                default:
                    subItem.ForeColor = listView1.ForeColor; // Default color if no match
                    break;
            }
        }

        private void SetEquipStatusColorCode(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Good":
                case "In-Use":
                    subItem.BackColor = Color.Green;
                    break;
                case "Borrowed":
                case "Unavailable":
                    subItem.BackColor = Color.Orange;
                    break;
                case "Damaged":
                case "In-Repair":
                    subItem.BackColor = Color.Red;
                    break;
                default:
                    subItem.BackColor = Color.White; // Default background color if no match
                    break;
            }
        }

        private void SearchEqup_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
            BuildSelect3();
            List<EquipmentData> searchList = _memberController.SearchEquipment(_strFilter1, _strSort1);
            if (searchList.Count > 0)
            {
                DisplayEquipmentSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.EquipmentId);


                lblTotal.Text = $"Total Equipment is:{totalWorkerNo.ToString("N")}";
                labelReportEqp.Text = $"Number of Equipment found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {
                lblWorkerReport.Text = "No Equipment found!";

                lblTotal.Text = "Total Amount is:0.00";
                ClearInputFields();
            }
        }
        private void BuildSelect3()
        {

            string equipmentName = texteqpName.Text;
            string brand = textBrand.Text;
            string status = Convert.ToString(cmbStaEqu.SelectedValue);

            string strWhere = "";
            _strFilter1 = "";
            _strSort1 = "equipmentName,brand,status";


            if (dtpEqpfrom.CustomFormat != " " && dtpEqpTo.CustomFormat != " ")
            {
                DateTime dtFrom = this.dtpEqpfrom.Value.Date;
                DateTime dtTo = this.dtpEqpTo.Value.Date;

                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere += "(";

                _strFilter1 = string.Format("DateCreated BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", dtFrom, dtTo);
                strWhere += _strFilter1 + ")";
            }

            if (!string.IsNullOrEmpty(equipmentName))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("equipmentName  LIKE '%{0}%' ", equipmentName); // Append to the existing filter
                strWhere += _strFilter1 + ")";
            }

            if (!string.IsNullOrEmpty(brand))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("brand  LIKE '%{0}%' ", brand); // Append to the existing filter
                strWhere += _strFilter1 + ")";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter1 = string.Format("status  LIKE '%{0}%' ", status); // Append to the existing filter
                strWhere += _strFilter1 + ")";
            }


            if (strWhere.Length > 0)
                _strFilter1 = strWhere;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView4.SelectedItems[0];

                EquipmentData selectedMember = new EquipmentData()
                {
                    EquipmentName = selectedItem.SubItems[0].Text,
                    Brand = selectedItem.SubItems[1].Text,
                    Quantity = int.Parse(selectedItem.SubItems[2].Text),
                    PurchasePrice = decimal.Parse(selectedItem.SubItems[3].Text),
                    StatusDescrip = selectedItem.SubItems[4].Text,
                    PurchasedDate = DateTime.Parse(selectedItem.SubItems[6].Text),
                    DateCreated = DateTime.Parse(selectedItem.SubItems[7].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[8].Text),



                    // Make sure to populate other properties based on ListView columns

                };

                CreateEquipment createMemberForm = new CreateEquipment(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Equipment record selected. Please perform a search and select equipment record to update.", MessageBoxIcon.Information);
            }
        }

        private void btnEquipPrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<EquipmentData> members = new List<EquipmentData>();
            foreach (ListViewItem item in listView4.Items)
            {
                DateTime purchasedDate;
                if (!DateTime.TryParseExact(item.SubItems[7].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out purchasedDate))
                {
                    purchasedDate = DateTime.MinValue; // Handle as needed
                }

                DateTime dateCreated;
                if (!DateTime.TryParseExact(item.SubItems[8].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated))
                {
                    dateCreated = DateTime.MinValue; // Handle as needed
                }

                DateTime dateModified;
                if (!DateTime.TryParseExact(item.SubItems[9].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified))
                {
                    dateModified = DateTime.MinValue; // Handle as needed
                }
                EquipmentData member = new EquipmentData()
                {
                    EquipmentId = int.Parse(item.SubItems[0].Text),
                    EquipmentName = item.SubItems[1].Text,
                    Brand = item.SubItems[2].Text,     
                    Quantity = int.Parse(item.SubItems[3].Text),
                    PurchasePrice = decimal.Parse(item.SubItems[4].Text),
                    Status = item.SubItems[5].Text,
                    PurchasedDate = purchasedDate,
                    DateCreated = dateCreated,
                    DateModified = dateModified,




                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Equipment Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "EquipmentReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet3", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }

        #endregion


        //************************************************MARRIAGE*******************************************
        #region MARRIAGE
        private void btnMarriageAdd_Click(object sender, EventArgs e)
        {
            CreateMarriage exp = new CreateMarriage(_connectionString);
            exp.ShowDialog();
        }
        private bool DisplayMarriageSearchResult(List<MarriageData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (MarriageData marriage in searchList)
            {
                //Note the items here must be arranged accordingly to how it is coming from the db, so that it does not take a value of a column and put it in another column
                ListViewItem listViewItem = new ListViewItem(marriage.MarriageId.ToString());
                listViewItem.SubItems.Add(marriage.CoupleName);
                listViewItem.SubItems.Add(marriage.CertificateName);
                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, marriage.StatusDescrip);
                SetMarriageStatusTextColor(statusSubItem, marriage.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetMarriageStatusColorCode(colorCodeSubItem, marriage.StatusDescrip); // Set color code based on status


                listViewItem.SubItems.Add(colorCodeSubItem);
                listViewItem.SubItems.Add(marriage.Reason);
                listViewItem.SubItems.Add(marriage.OfficiatingMinisters);
                listViewItem.SubItems.Add(marriage.ScheduledDate.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(marriage.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(marriage.DateModified.ToString("yyyy-MM-dd"));


                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling
                listView5.Items.Add(listViewItem);
            }


            return true;
        }

        private void SetMarriageStatusTextColor(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Concluded":
                    subItem.ForeColor = Color.Green;
                    break;
                case "Pending":
                case "on-Hold":
                    subItem.ForeColor = Color.Orange;
                    break;
                case "Suspended":
                case "Postponed":
                case "Waiting-Approval":
                case "In-Counselling":
                    subItem.ForeColor = Color.Red;
                    break;
                default:
                    subItem.ForeColor = listView1.ForeColor; // Default color if no match
                    break;
            }
        }

        private void SetMarriageStatusColorCode(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Concluded":
                    subItem.BackColor = Color.Green;
                    break;
                case "Pending":
                case "on-Hold":
                    subItem.BackColor = Color.Orange;
                    break;
                case "Suspended":
                case "Postponed":
                case "Waiting-Approval":
                case "In-Counselling":
                    subItem.BackColor = Color.Red;
                    break;
                default:
                    subItem.BackColor = Color.White; // Default background color if no match
                    break;
            }
        }
        private void btnMarriageUpdate_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView5.SelectedItems[0];

                MarriageData selectedMember = new MarriageData()
                {
                    CoupleName = selectedItem.SubItems[0].Text,
                    CertificateName = selectedItem.SubItems[1].Text,
                    StatusDescrip = selectedItem.SubItems[2].Text,
                    Reason = selectedItem.SubItems[4].Text,
                    OfficiatingMinisters = selectedItem.SubItems[5].Text,
                    ScheduledDate = DateTime.Parse(selectedItem.SubItems[6].Text),
                    DateCreated = DateTime.Parse(selectedItem.SubItems[7].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[8].Text),



                    // Make sure to populate other properties based on ListView columns

                };

                CreateMarriage createMemberForm = new CreateMarriage(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Marriage record selected, kindly select marriage record and click update.", MessageBoxIcon.Information);
            }
        }
        private void btnMarriageSearch_Click(object sender, EventArgs e)
        {
            listView5.Items.Clear();
            BuildSelect4();
            List<MarriageData> searchList = _memberController.SearchMarriage(_strFilter1, _strSort1);
            if (searchList.Count > 0)
            {
                DisplayMarriageSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.MarriageId);


                //lblTotal.Text = $"Total Amount is:{totalWorkerNo.ToString("N")}";
                label25.Text = $"Number of Marriage found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {
                label25.Text = "No Marriage Record!";

                lblTotal.Text = "Total Marriage is:0.00";
                ClearInputFields();
            }
        }

        private void BuildSelect4()
        {

            string status = Convert.ToString(cmbMarriageStatus.SelectedValue);
            string couplename = txtCoupName.Text;
            //DateTime scheduleddate = dtpScheduledDate.Value.Date;

            // Get the values from the scheduled date pickers
            DateTime scheduledDateFrom = dtpScheduledFrom.Value.Date;
            DateTime scheduledDateTo = dtpScheduledTo.Value.Date;

            string strWhere = "";
            _strFilter1 = "";
            _strSort1 = "status,couplename,scheduleddate";

            if (dateTimePicker4.CustomFormat != " " && dateTimePicker3.CustomFormat != " ")
            {
                DateTime dtFrom = this.dateTimePicker4.Value.Date;
                DateTime dtTo = this.dateTimePicker3.Value.Date;

                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"DateCreated BETWEEN '{dtFrom:yyyy-MM-dd}' AND '{dtTo:yyyy-MM-dd}'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"status LIKE '%{status}%'";
            }

            if (!string.IsNullOrEmpty(couplename))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"couplename LIKE '%{couplename}%'";
            }

            if (dtpScheduledFrom.CustomFormat != " " && dtpScheduledTo.CustomFormat != " ")
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"scheduleddate BETWEEN '{scheduledDateFrom:yyyy-MM-dd}' AND '{scheduledDateTo:yyyy-MM-dd}'";
            }

            if (!string.IsNullOrEmpty(strWhere))
                _strFilter1 = strWhere;
        }


        private void btnMarriagePrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<MarriageData> members = new List<MarriageData>();
            foreach (ListViewItem item in listView5.Items)
            {
                DateTime scheduledDate;
                if (!DateTime.TryParseExact(item.SubItems[7].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out scheduledDate))
                {
                    scheduledDate = DateTime.MinValue; // Handle as needed
                }

                DateTime dateCreated;
                if (!DateTime.TryParseExact(item.SubItems[8].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated))
                {
                    dateCreated = DateTime.MinValue; // Handle as needed
                }

                DateTime dateModified;
                if (!DateTime.TryParseExact(item.SubItems[9].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified))
                {
                    dateModified = DateTime.MinValue; // Handle as needed
                }
                MarriageData member = new MarriageData()
                {
                    MarriageId = int.Parse(item.SubItems[0].Text),
                    CoupleName = item.SubItems[1].Text,
                    CertificateName = item.SubItems[2].Text,
                    Status = item.SubItems[3].Text,
                    Reason = item.SubItems[5].Text,
                    OfficiatingMinisters = item.SubItems[5].Text,
                    ScheduledDate = scheduledDate,
                    DateCreated = dateCreated,
                    DateModified = dateModified,




                };
                members.Add(member);
               
            }
            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Marriage Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "MarriageReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet5", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }
        #endregion

        //*********************************************DEDICATION*******************************************************

        #region DEDICATION
        private void btnDedicationaAdd_Click(object sender, EventArgs e)
        {
            CreateDedication exp = new CreateDedication(_connectionString);
            exp.ShowDialog();
        }

        private void btnSearchDedication_Click(object sender, EventArgs e)
        {
            listView6.Items.Clear();
            BuildSelect5();
            List<DedicationData> searchList = _memberController.SearchDedication(_strFilter1, _strSort1);
            if (searchList.Count > 0)
            {
                DisplayDedicationSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.DedicationId);


                label25.Text = $"Total Amount is:{totalWorkerNo.ToString("N")}";
                label37.Text = $"Number of Dedications found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {
                label37.Text = "No Dedication Record!";

                lblTotal.Text = "Total Dedication is:0.00";
                ClearInputFields();
            }
        }

        private bool DisplayDedicationSearchResult(List<DedicationData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (DedicationData marriage in searchList)
            {
                //Note the items here must be arranged accordingly to how it is coming from the db, so that it does not take a value of a column and put it in another column
                ListViewItem listViewItem = new ListViewItem(marriage.DedicationId.ToString());
                listViewItem.SubItems.Add(marriage.Name);
                listViewItem.SubItems.Add(marriage.CertificateName);
                listViewItem.SubItems.Add(marriage.OfficiatingMinisters);
                listViewItem.SubItems.Add(marriage.DedicationDate.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(marriage.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(marriage.DateModified.ToString("yyyy-MM-dd"));

                listView6.Items.Add(listViewItem);
            }


            return true;
        }
        private void BuildSelect5()
        {


            string name = txtWokFname.Text;


            string strWhere = "";
            _strFilter1 = "";
            _strSort1 = "name";

            if (dtpDedicationFrom.CustomFormat != " " && dtpDedicationTo.CustomFormat != " ")
            {
                DateTime dtFrom = this.dtpDedicationFrom.Value.Date;
                DateTime dtTo = this.dtpDedicationTo.Value.Date;

                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"DateCreated BETWEEN '{dtFrom:yyyy-MM-dd}' AND '{dtTo:yyyy-MM-dd}'";
            }

            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"name LIKE '%{name}%'";
            }

            if (!string.IsNullOrEmpty(strWhere))
                _strFilter1 = strWhere;
        }
        private void btnUpdateDedication_Click(object sender, EventArgs e)
        {
            if (listView6.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView6.SelectedItems[0];

                DedicationData selectedMember = new DedicationData()
                {
                    Name = selectedItem.SubItems[0].Text,
                    CertificateName = selectedItem.SubItems[1].Text,
                    OfficiatingMinisters = selectedItem.SubItems[2].Text,
                    DedicationDate = DateTime.Parse(selectedItem.SubItems[3].Text),
                    DateCreated = DateTime.Parse(selectedItem.SubItems[4].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[5].Text)
                };

                CreateDedication createMemberForm = new CreateDedication(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Dedication record selected, kindly select marriage record and click update.", MessageBoxIcon.Information);
            }

        }

        private void btnDedicationPrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<DedicationData> members = new List<DedicationData>();
            foreach (ListViewItem item in listView6.Items)
            {
                DateTime dedicationDate;
                if (!DateTime.TryParseExact(item.SubItems[4].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dedicationDate))
                {
                    dedicationDate = DateTime.MinValue; // Handle as needed
                }

                DateTime dateCreated;
                if (!DateTime.TryParseExact(item.SubItems[5].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated))
                {
                    dateCreated = DateTime.MinValue; // Handle as needed
                }

                DateTime dateModified;
                if (!DateTime.TryParseExact(item.SubItems[6].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified))
                {
                    dateModified = DateTime.MinValue; // Handle as needed
                }
                DedicationData member = new DedicationData()
                {
                    DedicationId = int.Parse(item.SubItems[0].Text),
                    Name = item.SubItems[1].Text,
                    CertificateName = item.SubItems[2].Text,
                    OfficiatingMinisters = item.SubItems[3].Text,
                    DedicationDate = dedicationDate,
                    DateCreated = dateCreated,
                    DateModified = dateModified,




                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Dedication Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "DedicationReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet4", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }
        #endregion


        //******************************************************PROGRAM*******************************************************
        #region PROGRAM
        private void btnAddProg_Click(object sender, EventArgs e)
        {
            CreateProgram exp = new CreateProgram(_connectionString);
            exp.ShowDialog();
        }
        private bool DisplayProgramSearchResult(List<ProgramItenaryData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (ProgramItenaryData program in searchList)
            {
                ListViewItem listViewItem = new ListViewItem(program.ProgramId.ToString());
                listViewItem.SubItems.Add(program.NameOfProgram);
                listViewItem.SubItems.Add(program.Topic);
                listViewItem.SubItems.Add(program.Text);
                listViewItem.SubItems.Add(program.Reason);

                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, program.StatusDescrip);
                SetProgramStatusTextColor(statusSubItem, program.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetProgramStatusColorCode(colorCodeSubItem, program.StatusDescrip); // Set color code based on status
                listViewItem.SubItems.Add(colorCodeSubItem);

                // Add other columns
                listViewItem.SubItems.Add(program.Minister);
                listViewItem.SubItems.Add(program.GuestMinisters);
                listViewItem.SubItems.Add(program.OtherOfficiatingMinisters);
                listViewItem.SubItems.Add(program.TimeofProgram);
                listViewItem.SubItems.Add(program.DateOfProgram.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(program.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(program.DateModified.ToString("yyyy-MM-dd"));

                listViewItem.Tag = program.ProgramId; // Store ProgramId in the Tag property
                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling

                listView7.Items.Add(listViewItem);
            }

            return true;
        }
        private void SetProgramStatusTextColor(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Concluded":
                    subItem.ForeColor = Color.Green;
                    break;
                case "Pending":
                case "On-Hold":
                    subItem.ForeColor = Color.Orange;
                    break;
                case "Suspended":
                case "Postponed":
                case "Waiting-Approval":
                    subItem.ForeColor = Color.Red;
                    break;
                default:
                    subItem.ForeColor = listView1.ForeColor; // Default color if no match
                    break;
            }
        }
        private void SetProgramStatusColorCode(ListViewItem.ListViewSubItem subItem, string statusDescrip)
        {
            switch (statusDescrip)
            {
                case "Concluded":
                    subItem.BackColor = Color.Green;
                    break;
                case "Pending":
                case "On-Hold":
                    subItem.BackColor = Color.Orange;
                    break;
                case "Suspended":
                case "Postponed":
                case "Waiting-Approval":
                    subItem.BackColor = Color.Red;
                    break;
                default:
                    subItem.BackColor = Color.White; // Default background color if no match
                    break;
            }
        }
        private void BuildSelect6()
        {
            string NameOfProgram = textProgName.Text;
            string minister = textMinister.Text;
            string status = Convert.ToString(comboStatus.SelectedValue);

            string strWhere = "";
            _strFilter1 = "";
            _strSort1 = "NameOfProgram,minister,status";

            if (dtpProgFrom.CustomFormat != " " && dtpProgTo.CustomFormat != " ")
            {
                DateTime dtFrom = this.dtpProgFrom.Value.Date;
                DateTime dtTo = this.dtpProgTo.Value.Date.AddDays(1); // Add one day to include the entire dtTo day

                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere += "(";

                _strFilter1 = string.Format("DateCreated >= '{0:yyyy-MM-dd}' AND DateCreated < '{1:yyyy-MM-dd}'", dtFrom, dtTo);
                strWhere += _strFilter1 + ")";
            }

            if (!string.IsNullOrEmpty(NameOfProgram))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"NameOfProgram LIKE '%{NameOfProgram}%'";
            }

            if (!string.IsNullOrEmpty(minister))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"minister LIKE '%{minister}%'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (!string.IsNullOrEmpty(strWhere))
                    strWhere += " AND ";
                strWhere += $"status LIKE '%{status}%'";
            }

            if (strWhere.Length > 0)
                _strFilter1 = strWhere;
        }
        private void btnUpdateProg_Click(object sender, EventArgs e)
        {
            if (listView7.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView7.SelectedItems[0];
                int programId = (int)selectedItem.Tag; // Retrieve ProgramId from the Tag property


                ProgramItenaryData selectedMember = new ProgramItenaryData()
                {
                    ProgramId = programId, // Set the ProgramId
                    NameOfProgram = selectedItem.SubItems[0].Text,
                    Topic = selectedItem.SubItems[1].Text,
                    Text = selectedItem.SubItems[2].Text,
                    Reason = selectedItem.SubItems[3].Text,
                    Status = selectedItem.SubItems[4].Text,
                    Minister = selectedItem.SubItems[6].Text,
                    GuestMinisters = selectedItem.SubItems[7].Text,
                    OtherOfficiatingMinisters = selectedItem.SubItems[8].Text,
                    TimeofProgram = selectedItem.SubItems[9].Text,
                    DateOfProgram = DateTime.Parse(selectedItem.SubItems[10].Text),
                    DateCreated = DateTime.Parse(selectedItem.SubItems[11].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[12].Text)
                };

                CreateProgram createMemberForm = new CreateProgram(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Dedication record selected, kindly select marriage record and click update.", MessageBoxIcon.Information);
            }
        }
        private void btnSearchProg_Click(object sender, EventArgs e)
        {
            listView7.Items.Clear();
            BuildSelect6();
            List<ProgramItenaryData> searchList = _memberController.SearchProgram(_strFilter1, _strSort1);
            if (searchList.Count > 0)
            {
                DisplayProgramSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.ProgramId);


                label37.Text = $"Total Amount is:{totalWorkerNo.ToString("N")}";
                label40.Text = $"Number of Program found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {
                label40.Text = "No Program Record!";

                lblTotal.Text = "Total Program is:0.00";
                ClearInputFields();
            }
        }

        private void btnProgramPrint_Click(object sender, EventArgs e)
        {
            List<ProgramItenaryData> members = new List<ProgramItenaryData>();
            foreach (ListViewItem item in listView7.Items)
            {
                DateTime programDate;
                if (!DateTime.TryParseExact(item.SubItems[11].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out programDate))
                {
                    programDate = DateTime.MinValue; // Handle as needed
                }

                DateTime dateCreated;
                if (!DateTime.TryParseExact(item.SubItems[12].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated))
                {
                    dateCreated = DateTime.MinValue; // Handle as needed
                }

                DateTime dateModified;
                if (!DateTime.TryParseExact(item.SubItems[13].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified))
                {
                    dateModified = DateTime.MinValue; // Handle as needed
                }
                ProgramItenaryData member = new ProgramItenaryData()
                {
                    ProgramId = int.Parse(item.SubItems[0].Text),
                    NameOfProgram = item.SubItems[1].Text,
                    Topic = item.SubItems[2].Text,
                    Text = item.SubItems[3].Text,
                    Reason = item.SubItems[4].Text,
                    Status = item.SubItems[5].Text,
                    Minister = item.SubItems[7].Text,
                    GuestMinisters = item.SubItems[8].Text,
                    OtherOfficiatingMinisters = item.SubItems[9].Text,
                    TimeofProgram = item.SubItems[10].Text,
                    DateOfProgram = programDate,
                    DateCreated = dateCreated,
                    DateModified = dateModified,


                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Program Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "ProgramReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet7", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }
        #endregion



        //*********************************************APPOINTMENT RECORD******************************************************
        #region Appointment

        private void btnAppointmentAdd_Click(object sender, EventArgs e)
        {
            CreateAppointment exp = new CreateAppointment(_connectionString);
            exp.ShowDialog();
        }



        private bool DisplayAppointmentSearchResult(List<AppointmentManagementData> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (AppointmentManagementData appointment in searchList)
            {
                //Note the items here must be arranged accordingly to how it is coming from the db, so that it does not take a value of a column and put it in another column
                ListViewItem listViewItem = new ListViewItem(appointment.AppointmentId.ToString());
                listViewItem.SubItems.Add(appointment.VisitorName);
                listViewItem.SubItems.Add(appointment.Sex);
                listViewItem.SubItems.Add(appointment.PhoneNo);
                listViewItem.SubItems.Add(appointment.WhomToSee);
                listViewItem.SubItems.Add(appointment.Purpose);

                // Status column subitem
                ListViewItem.ListViewSubItem statusSubItem = new ListViewItem.ListViewSubItem(listViewItem, appointment.StatusDescrip);
                SetProgramStatusTextColor(statusSubItem, appointment.StatusDescrip); // Set text color based on status
                listViewItem.SubItems.Add(statusSubItem);

                // Status Code column subitem (color indicator)
                ListViewItem.ListViewSubItem colorCodeSubItem = new ListViewItem.ListViewSubItem(listViewItem, " "); // Add a space to display the color
                SetProgramStatusColorCode(colorCodeSubItem, appointment.StatusDescrip); // Set color code based on status
                listViewItem.SubItems.Add(colorCodeSubItem);

                //listViewItem.SubItems.Add(appointment.StatusDescrip);
                listViewItem.SubItems.Add(appointment.Reason);
                listViewItem.SubItems.Add(appointment.AppointmentTime);
                listViewItem.SubItems.Add(appointment.AppointmentDate.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(appointment.DateCreated.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(appointment.DateModified.ToString("yyyy-MM-dd"));

                listViewItem.Tag = appointment.AppointmentId; // Store ProgramId in the Tag property

                listViewItem.UseItemStyleForSubItems = false; // Allow individual subitem styling
                listView3.Items.Add(listViewItem);
            }


            return true;
        }

        private void btnUpdateApp_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView3.SelectedItems[0];
                int appointId = (int)selectedItem.Tag; // Retrieve ProgramId from the Tag property


                AppointmentManagementData selectedMember = new AppointmentManagementData()
                {
                    AppointmentId = appointId, // Set the ProgramId
                    VisitorName = selectedItem.SubItems[0].Text,
                    Sex = selectedItem.SubItems[1].Text,
                    PhoneNo = selectedItem.SubItems[2].Text,
                    WhomToSee = selectedItem.SubItems[3].Text,
                    Purpose = selectedItem.SubItems[4].Text,
                    Status = selectedItem.SubItems[5].Text,
                    Reason = selectedItem.SubItems[7].Text,
                    AppointmentTime = selectedItem.SubItems[8].Text,
                    AppointmentDate = DateTime.Parse(selectedItem.SubItems[9].Text),
                    DateCreated = DateTime.Parse(selectedItem.SubItems[10].Text),
                    DateModified = DateTime.Parse(selectedItem.SubItems[11].Text)
                };

                CreateAppointment createMemberForm = new CreateAppointment(_connectionString, selectedMember);
                createMemberForm.ShowDialog();
            }
            else
            {
                DisplayMessage("No Appointment record selected, kindly select appointment record and click update.", MessageBoxIcon.Information);
            }
        }

        string _strFilter2 = "";
        string _strSort2;

        private void BuildSelect7()
        {
            string status = Convert.ToString(cmbAppointStatus.SelectedValue);

            string strWhere1 = "";
            _strFilter2 = "";
            _strSort2 = "status";

            if (dtpAppointmentFrom.CustomFormat != " " && dtpAppointmentTo.CustomFormat != " ")
            {
                DateTime dtFrom = this.dtpAppointmentFrom.Value.Date;
                //DateTime dtTo = this.dtpAppointmentTo.Value.Date;
                DateTime dtTo = this.dtpAppointmentTo.Value.Date.AddDays(1);  // Add one day to include the end date


                strWhere1 += $"DateCreated >= '{dtFrom:yyyy-MM-dd}' AND DateCreated <= '{dtTo:yyyy-MM-dd}'";
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (!string.IsNullOrEmpty(strWhere1))
                    strWhere1 += " AND ";
                strWhere1 += $"status LIKE '%{status}%'";
            }

            if (!string.IsNullOrEmpty(strWhere1))
                _strFilter2 = "WHERE " + strWhere1;
            else
                _strFilter2 = "";
        }

        private void btnAppointSearch_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            BuildSelect7();
            List<AppointmentManagementData> searchList = _memberController.SearchAppointment(_strFilter2, _strSort2);
            if (searchList.Count > 0)
            {
                DisplayAppointmentSearchResult(searchList);
                decimal totalWorkerNo = searchList.Sum(item => item.AppointmentId);


                label37.Text = $"Total Amount is:{totalWorkerNo.ToString("N")}";
                label10.Text = $"Number of Appointment found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {

                label10.Text = "No Appointment Record!";

                lblTotal.Text = "Total Appointment is:0.00";
                ClearInputFields();
            }
        }

        private void btnAppointmentPrint_Click(object sender, EventArgs e)
        {
            // Step 1: Prepare the Data
            List<AppointmentManagementData> members = new List<AppointmentManagementData>();
            foreach (ListViewItem item in listView3.Items)
            {
                DateTime appointmentDate;
                if (!DateTime.TryParseExact(item.SubItems[10].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out appointmentDate))
                {
                    appointmentDate = DateTime.MinValue; // Handle as needed
                }

                DateTime dateCreated;
                if (!DateTime.TryParseExact(item.SubItems[11].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateCreated))
                {
                    dateCreated = DateTime.MinValue; // Handle as needed
                }

                DateTime dateModified;
                if (!DateTime.TryParseExact(item.SubItems[12].Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateModified))
                {
                    dateModified = DateTime.MinValue; // Handle as needed
                }
                AppointmentManagementData member = new AppointmentManagementData()
                {
                    AppointmentId = int.Parse(item.SubItems[0].Text.ToString()),
                    VisitorName = item.SubItems[1].Text,
                    Sex = item.SubItems[2].Text,
                    PhoneNo = item.SubItems[3].Text,
                    WhomToSee = item.SubItems[4].Text,
                    Purpose = item.SubItems[5].Text,
                    Status = item.SubItems[6].Text,
                    Reason = item.SubItems[8].Text,
                    AppointmentTime = item.SubItems[9].Text,
                    AppointmentDate = appointmentDate,
                    DateCreated = dateCreated,
                    DateModified = dateModified,




                };
                members.Add(member);
            }

            // Step 2: Set up the ReportViewer
            using (Form reportForm = new Form())
            {
                reportForm.Text = "Appointment Report";
                reportForm.Width = 800;
                reportForm.Height = 600;

                ReportViewer reportViewer = new ReportViewer();
                reportViewer.Dock = DockStyle.Fill;
                reportViewer.LocalReport.ReportPath = "AppointmentReport.rdlc"; // Ensure the path is correct
                reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet6", members); // Name must match the dataset in RDLC
                reportViewer.LocalReport.DataSources.Add(rds);

                reportViewer.RefreshReport();

                reportForm.Controls.Add(reportViewer);
                reportForm.ShowDialog();
            }
        }

        #endregion

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            string updateText = txtUpdateInput.Text.Trim();

            // Check if the text is not empty
            if (!string.IsNullOrEmpty(updateText))
            {
                // Add the text to the ListBox
                Updates.Items.Add(updateText);

                // Optionally, clear the TextBox for new input
                txtUpdateInput.Clear();
            }

        }

       
    }
}
