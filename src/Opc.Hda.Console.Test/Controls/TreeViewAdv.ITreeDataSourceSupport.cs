using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Fond.TreeDataSource;
using Opc.Hda.Controls.Tree;
using Opc.Hda.Controls.Tree.NodeControls;

namespace Opc.Hda.Controls
{
    public delegate object ExtractNodeValueDelegateAdv(object nodeValue);

    public static class TreeViewAdvMethodExtensions
    {
        public const string ColumnThisForItreeDataSource = "this";

        public static void AllocateITreeDataSource(this TreeViewAdv tree, ITreeDataSource dataSource, bool isVirtualMode)
        {
            tree.BeginUpdate();

            PrepareAllocateITreeDataSource(tree, dataSource, isVirtualMode);
            tree.Model = new TreeModelForITreeDataSource(dataSource);

            tree.EndUpdate();
        }

        private static void PrepareAllocateITreeDataSource(TreeViewAdv tree, ITreeDataSource dataSource, bool isVirtualMode)
        {
            tree.Model = null;
            tree.LoadOnDemand = isVirtualMode;
            tree.ColumnHeaderHeight = tree.ColumnHeaderHeight <= 0 ? 30 : tree.ColumnHeaderHeight;
            tree.UseColumns = true;

            if (dataSource == null)
            {
                return;
            }

            CheckNeedColumnsExistsOrAddIfNeededForITreeDataSource(tree, dataSource);
        }

        private static void CheckNeedColumnsExistsOrAddIfNeededForITreeDataSource(TreeViewAdv tree, ITreeDataSource dataSource)
        {
            if (dataSource == null || dataSource.SupportedColumns == null || dataSource.SupportedColumns.Count == 0)
            {
                return;
            }

            List<TreeColumn> columnsForAdd = new List<TreeColumn>();
            int index = 0;
            TreeColumn firstColumn = null;
            bool first = true;

            IList<ItreeDataSourceColumnInfo> supportedColumns = dataSource.SupportedColumns;
            int visibleColumnsCount = 0;
            foreach (ItreeDataSourceColumnInfo column in supportedColumns)
            {
                if (string.Equals(column.FieldName, ColumnThisForItreeDataSource))
                {
                    continue;
                }

                visibleColumnsCount++;
            }

            foreach (ItreeDataSourceColumnInfo supportedColumn in supportedColumns)
            {
                if (string.IsNullOrEmpty(supportedColumn.FieldName) || supportedColumn.Hidden)
                {
                    continue;
                }

                TreeColumn column = tree.Columns.GetColumnByFieldName(supportedColumn.FieldName);
                if (column == null)
                {
                    index++;
                    column = new TreeColumn();
                    column.Width = tree.Width / visibleColumnsCount;
                    column.FieldName = supportedColumn.FieldName;
                    column.Header = supportedColumn.Caption;
                    column.IsVisible = true;// VisibleIndex = this.Columns.Count - 1 + index;
                    columnsForAdd.Add(column);

                    NodeTextBox columnNodeControl = new NodeTextBox();
                    columnNodeControl.VirtualMode = true;
                    columnNodeControl.ValueNeeded += nodeTextBox_ValueNeeded;
                    columnNodeControl.DataPropertyName = column.FieldName;
                    columnNodeControl.EditEnabled = supportedColumn.AllowEdit;
                    columnNodeControl.ParentColumn = column;

                    tree.NodeControls.Add(columnNodeControl);
                }

                if (!string.IsNullOrEmpty(supportedColumn.Description))
                {
                    column.TooltipText = supportedColumn.Description;
                }

                if (supportedColumn.SortOrder != SortOrderEnum.None)
                {
                    column.SortOrder = (SortOrder)supportedColumn.SortOrder;
                }

                //if (supportedColumn.FixedLeft)
                //{
                //    column.Fixed = FixedStyle.Left;
                //}

                //// Колонка по умолчанию, содержащая значение узла
                if (column.FieldName == ColumnThisForItreeDataSource)
                {
                    column.IsVisible = false;
                }

                if (first)
                {
                    firstColumn = column;
                }

                first = false;
                //column.OptionsColumn.AllowEdit = supportedColumn.AllowEdit;
            }

            if (columnsForAdd.Count > 0)
            {
                foreach (TreeColumn column in columnsForAdd)
                {
                    tree.Columns.Add(column);
                }

                if (firstColumn != null && tree.Columns.Count == 2)
                {
                    //// Колонка в два раза шире остальных
                    tree.Columns.GetColumnByFieldName(firstColumn.FieldName).Width = (int)((tree.Width / visibleColumnsCount) * 1.5);
                }

                if (firstColumn != null && tree.Columns.Count > 2)
                {
                    //// Колонка в два раза шире остальных
                    tree.Columns.GetColumnByFieldName(firstColumn.FieldName).Width = (tree.Width / visibleColumnsCount) * 2;
                }
            }

            //// Добавим колонку this
            if (tree.Columns.GetColumnByFieldName(ColumnThisForItreeDataSource) == null)
            {
                TreeColumn columnThis = new TreeColumn(ColumnThisForItreeDataSource,ColumnThisForItreeDataSource,10);
                tree.Columns.Add(columnThis);
                columnThis.IsVisible = false;
            }
        }

        private static void nodeTextBox_ValueNeeded(object sender, NodeControlValueEventArgs e)
        {
            TreeViewAdv tree = e.Node.Tree;
            if (tree == null) return;
            if (e.NodeControl == null) return;

            object nodeValue = e.Node.Tag;

            string fieldName = ((BindableControl) e.NodeControl).DataPropertyName;
            if (string.IsNullOrEmpty(fieldName))
            {
                e.Value = nodeValue;
                return;
            }

            TreeModelForITreeDataSource model = tree.Model as TreeModelForITreeDataSource;
            if (model == null) return;


            bool handled;
            object cellValue = model.DataSource.GetCellValue(nodeValue, fieldName, out handled);
            if (handled)
            {
                e.Value = cellValue;
            }
        }
    }



    /// <summary>
    /// Обертка над <see cref="ITreeData"/> для присвоения к <see cref="TreeViewAdv"/>.
    ///</summary>
    public class TreeModelForITreeDataSource : TreeModelForITreeBase<ITreeDataSource>
    {
        public TreeModelForITreeDataSource(ITreeDataSource dataSource)
            : base(dataSource)
        {
        }
    }

    /// <summary>
    /// Обертка над <see cref="ITreeData"/> для присвоения к <see cref="TreeViewAdv"/>.
    ///</summary>
    public class TreeModelForITreeData : TreeModelForITreeBase<ITreeData>
    {
        public TreeModelForITreeData(ITreeData dataSource) : base(dataSource)
        {
        }
    }

    /// <summary>
    /// Обертка над <see cref="ITreeData"/> для присвоения к <see cref="TreeViewAdv"/>.
    ///</summary>
    public class TreeModelForITreeBase<T> : TreeModelBase where T: ITreeData
    {
        private readonly T dataSource;
        private readonly IList<object> emptyCollection = new object[]{};

        public TreeModelForITreeBase(T dataSource)
        {
            this.dataSource = dataSource;
        }

        public T DataSource
        {
            get { return this.dataSource; }
        }

        public override IEnumerable GetChildren(TreePath treePath)
        {
            object lastNode = treePath.LastNode;
            if (lastNode == null)
            {
                if (treePath.FirstNode != null)
                {
                    //// скорее всего шибочно подготовили ITreeData - в конце всегда должна быть пуская коллекция, а не null
                    return emptyCollection;
                }

                //// Root
                //return new[] { this.dataSource.RootNode };
                IList childsForRoot = this.dataSource.GetChilds(this.dataSource.RootNode);
                return childsForRoot;
            }

            IList childs = this.dataSource.GetChilds(lastNode);
            return childs;
        }

        public override bool IsLeaf(TreePath treePath)
        {
            object lastNode = treePath.LastNode;
            if (lastNode == null)
            {
                if (treePath.FirstNode != null)
                {
                    //// скорее всего шибочно подготовили ITreeData - в конце всегда должна быть пуская коллекция, а не null
                    return true;
                }

                lastNode = this.dataSource.RootNode;
            }

            IList childs = this.dataSource.GetChilds(lastNode);
            return childs == null || childs.Count == 0;
        }
    }
}
