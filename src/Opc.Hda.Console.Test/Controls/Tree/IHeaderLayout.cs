namespace Opc.Hda.Controls.Tree
{
  internal interface IHeaderLayout
  {
    int PreferredHeaderHeight
    {
      get;
      set;
    }

    void ClearCache();
  }
}
