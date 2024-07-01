#if NC
//using HostMgd.ApplicationServices;
//using HostMgd.EditorInput;

//using Teigha.DatabaseServices;

using App = HostMgd.ApplicationServices;
using Db = Teigha.DatabaseServices;
using Ed = HostMgd.EditorInput;
using Rtm = Teigha.Runtime;

#elif AC

//using Autodesk.AutoCAD.ApplicationServices;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.EditorInput;
//using Autodesk.AutoCAD.Windows;

using App = Autodesk.AutoCAD.ApplicationServices;
//using Cad = Autodesk.AutoCAD.ApplicationServices.Application;
using Db = Autodesk.AutoCAD.DatabaseServices;
using Ed = Autodesk.AutoCAD.EditorInput;
//using Gem = Autodesk.AutoCAD.Geometry;
using Rtm = Autodesk.AutoCAD.Runtime;


#endif
[assembly: Rtm.CommandClass(typeof(drz.Tools.CadCommand))]

namespace drz.Tools
{
    /// <summary> 
    /// Комманды
    /// </summary>
    class CadCommand : Rtm.IExtensionApplication
    {

        #region INIT
        public void Initialize()
        {
            //think добавить проверку есть ли doc

            App.DocumentCollection dm = App.Application.DocumentManager;


            Ed.Editor ed = dm.MdiActiveDocument.Editor;
            //!+Вывожу список команд определенных в библиотеке
            ed.WriteMessage("\nStart list of commands: \n");
            string sCom =
                "drz_changedb" + "\tПереключатель баз MultiCad";
            ed.WriteMessage(sCom);
            //ed.WriteMessage("End list of commands\n");

#if DEBUG
            //для отладки список команд, чтоб лишнего не попало
#endif           
        }

        public void Terminate()
        {
            // throw new System.NotImplementedException();
        }

        #endregion

        #region Command

        /// <summary>
        /// переключалка нанобаз
        /// </summary>
        [Rtm.CommandMethod("drz_changedb", Rtm.CommandFlags.Session)]
        public void changedbMod()
        {
            Db.Database db = Db.HostApplicationServices.WorkingDatabase;
            App.Document doc = App.Application.DocumentManager.MdiActiveDocument;
            Ed.Editor ed = doc.Editor;

            Ed.PromptStringOptions opts = new Ed.PromptStringOptions("enter base:");
            opts.AllowSpaces = true;
            Ed.PromptResult pr = ed.GetString(opts);
            if (Ed.PromptStatus.OK == pr.Status)
            {
                bool bSetBD = Multicad.AplicationServices.McParamManager.SetParam(pr.StringResult, 9);

            }
            //return;
            //string oldBd = Multicad.AplicationServices.McParamManager.GetStringParam(9);//получаем путь к базе текущего приложения

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
