using Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Contacts1 : System.Web.UI.Page
    {
        meetmeEntities data = new meetmeEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }

            SearchButton.Click += SearchButton_Click;

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //1. List of users searched for
            //2. Name filled in textbox to search for
            List<AspNetUsers> searchuser = null;
            string name = SearchBox.Text;

            //1. Temporary string with split of name
            //2. Length of temporary string
            string[] tmp = name.Split(' ');
            int words = tmp.Length;

            //1. Firstname filled in
            //2. Lastname if filled in
            string Firstname = tmp[0];
            string Lastname = "";

            if (words < 2)
            {
                searchuser = data.AspNetUsers.Where(ev => ev.Firstname == Firstname).ToList();
            }
            else {
                Lastname = tmp[1];
                searchuser = data.AspNetUsers.Where(ev => ev.Firstname == Firstname && ev.Lastname == Lastname).ToList();
            }

            foreach (var user in searchuser)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();
                TableCell checkbox = new TableCell();
                TableCell add = new TableCell();

                cell1.Text = user.Firstname;
                cell2.Text = user.Lastname;
                cell3.Text = user.UserName;
                checkbox.Controls.Add(new CheckBox());

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                ContactTable.Rows.Add(row);
            }
        }
    
    }
}