using System;
using System.Collections;
using System.Collections.Generic;
using Fond;
using Fond.TreeDataSource;

namespace Opc.Hda.Models
{
    public class OPCTagDefinitionTree : ITreeDataSource {
        private readonly OPCTagDefinition rootTag;

        /// <summary>
            /// Пустая коллекция для пустых коллекций дерева
            /// </summary>
            private readonly object[] emptyCollection = Array.Empty<object>();

            /// <summary>
            /// Список поддерживаемых колонок (FieldName, Caption). 
            /// !!! Реализовывать нужно через переменную, а не new ItreeDataSourceColumnInfo[]{}
            /// </summary>
            private IList<ItreeDataSourceColumnInfo> supportedColumns;

            /// <summary>
            /// Имя колонки, содержащей значение по умолчанию (не менять имя)
            /// (Она невидима при отображении дерева, но значение можно получить)
            /// </summary>
            private const string СolumnThis = "this";

            /// <summary>
            /// Пример колонки
            /// </summary>
            private const string columnName = "Name";
            private const string columnPath = "Path";
            private const string columnD = "D";
            private const string columnItemName = "ItemName";
            private const string columnPropValue = "PropValue";
            private const string columnPropDescription = "PropDescription";

            /// <summary>
            /// Корневой узел для заполнения виртуального дерева
            /// </summary>
            public object RootNode => "ROOT";

            public OPCTagDefinitionTree([NotNull] OPCTagDefinition rootNode)
            {
                this.rootTag = rootNode ?? throw new ArgumentNullException(nameof(rootNode));
            }

            /// <summary>
            /// Получить значение для определенной колонки дерева по ее FieldName
            /// </summary>
            /// <param name="nodeValue">Элемент, хранящийся в узле дерева(в данном случае wrapper_aliasable_technical_reference)</param>
            /// <param name="fieldName">FieldName у колонки</param>
            /// <param name="handled">Говорит о том, что значение для колонки <paramref name="fieldName"/> было получено. Иначе какой-то другой обработчик может дозаполнить поля и нужно вернуть false</param>
            /// <returns>Значение, присваиваемое ячейке в колонке с FiledName = <paramref name="fieldName"/></returns>
            object ITreeDataSource.GetCellValue(object nodeValue, string fieldName, out bool handled)
            {
                switch (fieldName)
                {
                    case СolumnThis:
                        handled = true;
                        return nodeValue;
                    case columnName:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od)
                        {
                            return od.Name;
                        }

                        return null; 
                    case columnPath:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od1)
                        {
                            return od1.Path;
                        }

                        return null; 
                    case columnD:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od2)
                        {
                            return od2.D;
                        }

                        return null;  
                    case columnItemName:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od3)
                        {
                            return od3.ItemName;
                        }

                        return null;
                    case columnPropValue:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od4)
                        {
                            return od4.PropValue;
                        }

                        return null;
                    case columnPropDescription:
                        handled = true;
                        if (nodeValue is OPCTagDefinition od5)
                        {
                            return od5.PropDescription;
                        }

                        return null;
                    default:
                        handled = false;
                        return nodeValue;
                }
            }

            /// <summary>
            /// Присвоить значение колонке дерева по ее FieldName
            /// </summary>
            /// <param name="nodeValue">Элемент, хранящийся в узле дерева(в данном случае wrapper_aliasable_technical_reference)</param>
            /// <param name="fieldName">FieldName у колонки</param>
            /// <param name="value">Присваимваемое значение</param>
            /// <param name="handled">Говорит о том, что значение для колонки <paramref name="fieldName"/> было получено. Иначе какой-то другой обработчик может дозаполнить поля и нужно вернуть false</param>
            /// <param name="errorText"></param>
            /// <returns>Присвоено значение или нет</returns>
            SetCellValueResultEnum ITreeDataSource.SetCellValue(object nodeValue, string fieldName, object value, ref bool handled, ref string errorText)
            {
                errorText = null;
                handled = false;
                return SetCellValueResultEnum.Ignore;
            }

            /// <summary>
            /// Список поддерживаемых колонок (FieldName, Caption). 
            /// !!! Реализовывать нужно через переменную, а не new ItreeDataSourceColumnInfo[]{}
            /// </summary>
            IList<ItreeDataSourceColumnInfo> ITreeDataSource.SupportedColumns
            {
                get {
                    if (this.supportedColumns == null)
                    {
                        this.supportedColumns = new ItreeDataSourceColumnInfo[] {
                            new ItreeDataSourceColumnInfo(columnName, "Name", false),
                            new ItreeDataSourceColumnInfo(columnItemName, "ItemName", false),
                            new ItreeDataSourceColumnInfo(columnPropDescription, "Description", false),
                            new ItreeDataSourceColumnInfo(columnPropValue, "PropValue", false),
                            new ItreeDataSourceColumnInfo(columnD, "D", false),
                        };
                    }

                    return this.supportedColumns;
                }
            }

            /// <summary>
            /// Получить подчиненные узлы по паренту (используется для заполнения дерева)
            /// </summary>
            /// <param name="nodeValue">Элемент, хранящийся в узле дерева(в данном случае wrapper_aliasable_technical_reference)</param>
            /// <returns>Коллекция подчиненных объектов</returns>
            IList ITreeData.GetChilds(object nodeValue)
            {
                if (nodeValue == this.RootNode)
                {
                    return this.rootTag.C;
                }

                if (nodeValue is OPCTagDefinition od)
                {
                    return od.C;
                }

                return this.emptyCollection;
            }

            /// <summary>
            /// Возвращает данные, которые ассоциированным с узлом дерева
            /// </summary>
            /// <param name="node">Узел дерева для получения данных</param>
            /// <returns>Данные хрянящиеся в узле дерева</returns>
            object ITreeData.GetNodeData(object node)
            {
                return node;
            }
        }}
