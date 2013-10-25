Public Class Form1

    ''' <summary>
    ''' ジョブ分割ロジック
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Listを用意
        Dim prtEntList As New List(Of Integer)

        '初期値設定
        For i = 0 To 9
            prtEntList.Add(i)
        Next

        Dim PrinterCnt = 1
        '印刷枚数
        Dim divide As Integer = CInt(Int(prtEntList.Count / PrinterCnt))
        Dim rest As Integer = prtEntList.Count Mod PrinterCnt
        Dim prtIdx As Integer = 0

        'その時点の発行枚数
        Dim nowCnt As Integer = 0

        For idx = 1 To PrinterCnt
            '印刷枚数よりプリンタが少ない場合の対応
            If prtEntList.Count > prtIdx Then

                'エンティティリスト取得
                Dim prtCnt As Integer = divide
                If idx <= rest Then
                    '余りがある場合はプラス1
                    prtCnt = prtCnt + 1
                End If
                Dim tmpPrtEntList = prtEntList.GetRange(prtIdx, prtCnt)
                prtIdx = prtIdx + prtCnt

                '分割枚数
                Dim divCnt As Integer = 10

                For i = 1 To tmpPrtEntList.Count Step divCnt

                    '印刷データの設定
                    Dim tmpDivCnt As Integer
                    If i + divCnt - tmpPrtEntList.Count > 0 Then
                        '最終ループの件数設定
                        tmpDivCnt = tmpPrtEntList.Count - (i - 1)
                    Else
                        tmpDivCnt = divCnt
                    End If


                    Dim outList = tmpPrtEntList.GetRange(i - 1, tmpDivCnt)
                    Console.WriteLine("ジョブ:" & outList.FirstOrDefault & "-" & outList(outList.Count - 1))


                    'その時点の発行件数を更新
                    nowCnt = nowCnt + tmpDivCnt

                Next

            End If
        Next



    End Sub
End Class
