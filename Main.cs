using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace RevitAPIRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown (UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup (UIControlledApplication application)
        {
            string tabName = "RevitAPITraining";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITraining1\";

            var panel = application.CreateRibbonPanel(tabName, "Revit's Plugins");
          
            var button1 = new PushButtonData("Система1", "Количество элементов",
                Path.Combine(utilsFolderPath, "RevitAPIUI1.dll"),
                "RevitAPIUI1.Main");

            var button2 = new PushButtonData("Система2", "Смена типа стен",
                Path.Combine(utilsFolderPath, "RevitAPIUI2.dll"),
                "RevitAPIUI2.Main");

            Uri uriImage1 = new Uri(@"C:\Program Files\RevitAPITraining1\Images\Revit1.png", UriKind.Absolute);
            BitmapImage largeImage1 = new BitmapImage(uriImage1);
            button1.LargeImage = largeImage1;

            Uri uriImage2 = new Uri(@"C:\Program Files\RevitAPITraining1\Images\Revit2.png", UriKind.Absolute);
            BitmapImage largeImage2 = new BitmapImage(uriImage2);
            button2.LargeImage = largeImage2;

            panel.AddItem(button1);
            panel.AddItem(button2);

            return Result.Succeeded;
        }
    }
}
