// Ignore Spelling: Changedb

using System.ComponentModel;

using drz.Infrastructure.Service;

using MC = Multicad.AplicationServices;
#if NC

using App = HostMgd.ApplicationServices;
using Db = Teigha.DatabaseServices;
using Ed = HostMgd.EditorInput;
using Rtm = Teigha.Runtime;

#elif AC
using App = Autodesk.AutoCAD.ApplicationServices;
using Db = Autodesk.AutoCAD.DatabaseServices;
using Ed = Autodesk.AutoCAD.EditorInput;
using Rtm = Autodesk.AutoCAD.Runtime;

#endif
[assembly: Rtm.CommandClass(typeof(drz.ChangeDBmod.CadCommand))]

namespace drz.ChangeDBmod
{
    /// <summary> 
    /// Команды 
    /// </summary>
    class CadCommand : Rtm.IExtensionApplication
    {
        #region INIT
        public void Initialize()
        {
            //выводим список команд с описаниями
            CmdInfo comInf = new CmdInfo();
            comInf.Reflection(); //модуль в этой сборке
        }

        public void Terminate()
        {
            // throw new System.NotImplementedException();
        }

        #endregion

        #region Command

        /// <summary>
        /// Переключатель баз MultiCad
        /// </summary>
        [Rtm.CommandMethod("drz_changedb", Rtm.CommandFlags.Session)]
        [Description("Переключатель баз MultiCad")]
        public void ChangedbMod()
        {
            App.Document doc = App.Application.DocumentManager.MdiActiveDocument;
            //Db.Database db = doc.Database;
            Ed.Editor ed = doc.Editor;

            Ed.PromptStringOptions opts = new Ed.PromptStringOptions("enter base:")
            {
                AllowSpaces = true
            };
            Ed.PromptResult pr = ed.GetString(opts);

            if (Ed.PromptStatus.OK == pr.Status)
            {
                _ = MC.McParamManager.SetParam(pr.StringResult, 9);
            }
            //Example switch other database;
            //string oldBd = Multicad.AplicationServices.McParamManager.GetStringParam(9);//получаем путь свойства базы текущего приложения

            //string sMDF = "z:\\BD_SQL\\nana\\std.mdf";//local *.mdf
            //bool bsetBD = Multicad.AplicationServices.McParamManager.SetParam(sMDF, 9);

            //string sSQL = "SQL:C-VGDSQL03:mc_spds9";
            //bsetBD = Multicad.AplicationServices.McParamManager.SetParam(sSQL, 9);

            //string sPSQL = "pgsql:nspds240";
            //bsetBD = Multicad.AplicationServices.McParamManager.SetParam(sPSQL, 9);

        }

        #endregion
    }
}
