Module extensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function NeddsItem(ByVal instance As Stack(Of Object()()), ByVal dgv As DataGridView) As Boolean
        If instance.Count = 0 Then Return True
        Dim rows()() As Object = instance.Peek '获取上一步步骤
        Return Not ItemEquals(rows, dgv.Rows.Cast(Of DataGridViewRow).Where(Function(r) Not r.IsNewRow).ToArray) '将上一步步骤与目前表格的情况相比较，相同时返回true,否则为false
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ItemEquals(ByVal instance As Object()(), ByVal dgvRows() As DataGridViewRow) As Boolean
        If instance.Count <> dgvRows.Count Then Return False
        '将传入的rows与目前表格的情况相比较。只要出现不一样的时候，返回true。否则为false
        Return Not Enumerable.Range(0, instance.GetLength(0)).Any(Function(x) Not instance(x).SequenceEqual(dgvRows(x).Cells.Cast(Of DataGridViewCell).Select(Function(c) c.Value).ToArray))
    End Function

End Module
