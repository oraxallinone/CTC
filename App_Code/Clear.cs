using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Clear
/// </summary>
public class Clear
{
	public Clear()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Clear_All(Control parent)
    {
        foreach (Control _ChildControl in parent.Controls)
        {
            if ((_ChildControl.Controls.Count > 0))
            {
                Clear_All(_ChildControl);
            }
            else
            {
                if (_ChildControl is TextBox)
                {
                    ((TextBox)_ChildControl).Text = string.Empty;
                }
                else if (_ChildControl is CheckBox)
                {
                    ((CheckBox)_ChildControl).Checked = false;
                }
                else if (_ChildControl.GetType().ToString() == "System.Web.UI.WebControls.DropDownList")
                {
                    DropDownList ddl = (DropDownList)_ChildControl;
                    if (ddl != null)
                        ddl.ClearSelection();
                }
                else if (_ChildControl.GetType().ToString() == "System.Web.UI.WebControls.RadioButton")
                {
                    ((RadioButton)_ChildControl).Checked = false;
                }
            }

        }
    }
}