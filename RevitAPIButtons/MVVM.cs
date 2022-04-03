using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIWallsTypeChange
{
    public class MVVM
    {
        private ExternalCommandData _commandData;
        public DelegateCommand saveCommand { get; }

        private DelegateCommand pickedObjects;

        public MVVM(ExternalCommandData commandData)
        {
            _commandData = commandData;
            saveCommand = new DelegateCommand(SaveCommand);
            //pickedObjects = new PickObjects(commandData);
        }

        public static List<Element> PickObjects(ExternalCommandData commandData, string msg = "Select Elements")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, msg);
            List<Element> elementList = selectedObjects.Select(selectedObject => doc.GetElement(selectedObject)).ToList();
            return elementList;
        }

        public static List<WallType> getWallTypes (ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<WallType> wallTypes = new FilteredElementCollector(doc)
                                           .OfClass(typeof(WallType))
                                           .Cast<WallType>()
                                           .ToList();
            return wallTypes;
        }

        private void SaveCommand()
        {
            throw new NotImplementedException();
        }
    }
}
