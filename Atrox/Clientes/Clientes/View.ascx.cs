﻿/*
' Copyright (c) 2016  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Christoc.Modules.Clientes
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from ClientesModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : ClientesModuleBase, IActionable
    {

        void ConfigHF() 
        {
            HF_Host.Value = "/DesktopModules/Clientes/API/ModuleTask/";
            Data2.Connection.D_StaticWebService SWS = new Data2.Connection.D_StaticWebService();
            K.Value = SWS.GetPrivateKeyByIdUser(UserId);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                ConfigHF();
                ConfigFields();

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void ConfigFields()
        {
            if (cmbprovincia.Items.Count == 0)
            {
                cmbprovincia.Items.Clear();
                List<Data2.Class.Struct_Provincia> LP = Data2.Class.Struct_Provincia.GetAll();
                Data2.Statics.Log.ADD(LP.Count.ToString(), this);
                if (LP != null && LP.Count > 0)
                {
                    for (int a = 0; a < LP.Count; a++)
                    {
                        ListItem LI = new ListItem(LP[a].getName(), LP[a].getName());

                        cmbprovincia.Items.Add(LI);
                    }
                }
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Data2.Class.Struct_Cliente CL = new Data2.Class.Struct_Cliente(
                txt_razonsocial.Text,
                txt_dnicuilcuit.Text,
                cmbpais.SelectedValue,
                cmbprovincia.SelectedValue,
                txt_localidad.Text,
                txt_domicilio.Text,
                txt_observaciones.Text,
                cmbsituacion.SelectedValue,
                Data2.Statics.Conversion.GetDecimal(txt_descuento.Text),
                txt_email.Text,
                UserId);
            CL.Guardar();
                

        }
    }
}