#region Copyright (C) 2005-2008 Team MediaPortal

/* 
 *	Copyright (C) 2005-2008 Team MediaPortal
 *	http://www.team-mediaportal.com
 *
 *  This Program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2, or (at your option)
 *  any later version.
 *   
 *  This Program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *   
 *  You should have received a copy of the GNU General Public License
 *  along with GNU Make; see the file COPYING.  If not, write to
 *  the Free Software Foundation, 675 Mass Ave, Cambridge, MA 02139, USA. 
 *  http://www.gnu.org/copyleft/gpl.html
 *
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.IO;

namespace MediaPortal.DeployTool
{
  public partial class MPSettingsWithoutTvEngineDlg : DeployDialog, IDeployDialog
  {
    public MPSettingsWithoutTvEngineDlg()
    {
      InitializeComponent();
      type = DialogType.MPSettingsWithoutTvEngine;
      textBoxDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Team MediaPortal\\MediaPortal";
      checkBoxFirewall.Text = Localizer.Instance.GetString("MPSettings_checkBoxFirewall");
      UpdateUI();
    }

    #region IDeployDialog interface
    public override void UpdateUI()
    {
      labelHeading.Text = Localizer.Instance.GetString("MPSettings_labelHeading");
      labelInstDir.Text = Localizer.Instance.GetString("MPSettings_labelInstDir");
      buttonBrowse.Text = Localizer.Instance.GetString("MPSettings_buttonBrowse");
    }
    public override DeployDialog GetNextDialog()
    {
      if (checkBoxFirewall.Enabled == true) InstallationProperties.Instance.Set("ConfigureMediaPortalFirewall", "1");
      return DialogFlowHandler.Instance.GetDialogInstance(DialogType.Installation);
    }
    public override bool SettingsValid()
    {
      if (!Utils.CheckTargetDir(textBoxDir.Text))
      {
        Utils.ErrorDlg(Localizer.Instance.GetString("MPSettings_errInvalidPath"));
        return false;
      }
      return true;
    }
    public override void SetProperties()
    {
      InstallationProperties.Instance.Set("MPDir", textBoxDir.Text);
    }
    #endregion

    private void buttonBrowse_Click(object sender, EventArgs e)
    {
      FolderBrowserDialog dlg = new FolderBrowserDialog();
      dlg.Description = Localizer.Instance.GetString("MPSettings_msgSelectDir");
      dlg.SelectedPath = textBoxDir.Text;
      if (dlg.ShowDialog() == DialogResult.OK)
        textBoxDir.Text = dlg.SelectedPath;
    }
  }
}
