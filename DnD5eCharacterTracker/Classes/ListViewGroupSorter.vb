Public Class ListViewGroupSorter

    Implements IComparer(Of ListViewGroup)

    Public Function Compare(ByVal x As System.Windows.Forms.ListViewGroup, ByVal y As System.Windows.Forms.ListViewGroup) As Integer Implements System.Collections.Generic.IComparer(Of System.Windows.Forms.ListViewGroup).Compare
        Return String.Compare(y.Header, x.Header)
    End Function

End Class
