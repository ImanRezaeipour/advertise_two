using Advertise.Core.Models.Common;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advertise.Service.Services.ExportImport.Help
{
    /// <summary>
    /// Class for working with PropertyByName object list
    /// </summary>
    /// <typeparam name="T">Object type</typeparam>
    public class PropertyManager<T>
    {
        #region Private Fields

        /// <summary>
        /// All properties
        /// </summary>
        private readonly Dictionary<string, PropertyByName<T>> _properties;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="properties">All acsess properties</param>
        public PropertyManager(IEnumerable<PropertyByName<T>> properties)
        {
            _properties = new Dictionary<string, PropertyByName<T>>();

            var poz = 1;
            foreach (var propertyByName in properties)
            {
                propertyByName.PropertyOrderPosition = poz;
                poz++;
                _properties.Add(propertyByName.PropertyName, propertyByName);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Capacity of properties
        /// </summary>
        public int Count => _properties.Count;

        /// <summary>
        /// Curent object to acsess
        /// </summary>
        public T CurrentObject { get; set; }

        /// <summary>
        /// Get property array
        /// </summary>
        public PropertyByName<T>[] GetProperties => _properties.Values.ToArray();

        /// <summary>
        ///
        /// </summary>
        public bool IsCaption
        {
            get { return _properties.Values.All(p => p.IsCaption); }
        }

        #endregion Public Properties

        #region Public Indexers

        /// <summary>
        /// Access object by property name
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns>Property value</returns>
        public object this[string propertyName] => _properties.ContainsKey(propertyName) && CurrentObject != null
            ? _properties[propertyName].GetProperty(CurrentObject)
            : null;

        #endregion Public Indexers

        #region Public Methods

        /// <summary>
        /// Return properti index
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public int GetIndex(string propertyName)
        {
            if (!_properties.ContainsKey(propertyName))
                return -1;

            return _properties[propertyName].PropertyOrderPosition;
        }

        /// <summary>
        /// Get property by name
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public PropertyByName<T> GetProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName) ? _properties[propertyName] : null;
        }

        /// <summary>
        /// Read object data from XLSX worksheet
        /// </summary>
        /// <param name="worksheet">worksheet</param>
        /// <param name="row">Row index</param>
        /// /// <param name="cellOffset">Cell offset</param>
        public void ReadFromXlsx(ExcelWorksheet worksheet, int row, int cellOffset = 0)
        {
            if (worksheet == null || worksheet.Cells == null)
                return;

            foreach (var prop in _properties.Values)
            {
                prop.PropertyValue = worksheet.Cells[row, prop.PropertyOrderPosition + cellOffset].Value;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="list"></param>
        public void SetSelectList(string propertyName, IList<SelectListItem> list)
        {
            var tempProperty = GetProperty(propertyName);
            if (tempProperty != null)
                tempProperty.DropDownElements = list;
        }

        /// <summary>
        /// Write caption (first row) to XLSX worksheet
        /// </summary>
        /// <param name="worksheet">worksheet</param>
        /// <param name="setStyle">Detection of cell style</param>
        /// <param name="row">Row num</param>
        /// <param name="cellOffset">Cell offset</param>
        public void WriteCaption(ExcelWorksheet worksheet, Action<ExcelStyle> setStyle, int row = 1, int cellOffset = 0)
        {
            foreach (var caption in _properties.Values)
            {
                var cell = worksheet.Cells[row, caption.PropertyOrderPosition + cellOffset];
                cell.Value = caption;
                setStyle(cell.Style);
            }
        }

        /// <summary>
        /// Write object data to XLSX worksheet
        /// </summary>
        /// <param name="worksheet">Data worksheet</param>
        /// <param name="row">Row index</param>
        /// <param name="exportImportUseDropdownlistsForAssociatedEntities">Indicating whether need create dropdown list for export</param>
        /// <param name="cellOffset">Cell offset</param>
        /// <param name="fWorksheet">Filters worksheet</param>
        public void WriteToXlsx(ExcelWorksheet worksheet, int row, bool exportImportUseDropdownlistsForAssociatedEntities, int cellOffset = 0, ExcelWorksheet fWorksheet = null)
        {
            if (CurrentObject == null)
                return;

            foreach (var prop in _properties.Values)
            {
                var cell = worksheet.Cells[row, prop.PropertyOrderPosition + cellOffset];
                if (prop.IsDropDownCell)
                {
                    var dropDownElements = prop.GetDropDownElements();
                    if (!dropDownElements.Any())
                    {
                        cell.Value = string.Empty;
                        continue;
                    }

                    cell.Value = prop.GetItemText(prop.GetProperty(CurrentObject));

                    if (!exportImportUseDropdownlistsForAssociatedEntities)
                        continue;

                    var validator = cell.DataValidation.AddListDataValidation();

                    validator.AllowBlank = prop.AllowBlank;

                    if (fWorksheet == null)
                        continue;

                    var fRow = 1;
                    foreach (var dropDownElement in dropDownElements)
                    {
                        var fCell = fWorksheet.Cells[fRow++, prop.PropertyOrderPosition];

                        if (fCell.Value != null && fCell.Value.ToString() == dropDownElement)
                            break;

                        fCell.Value = dropDownElement;
                    }

                    validator.Formula.ExcelFormula = $"{fWorksheet.Name}!{fWorksheet.Cells[1, prop.PropertyOrderPosition].Address}:{fWorksheet.Cells[dropDownElements.Length, prop.PropertyOrderPosition].Address}";
                }
                else
                {
                    cell.Value = prop.GetProperty(CurrentObject);
                }
            }
        }

        #endregion Public Methods
    }
}