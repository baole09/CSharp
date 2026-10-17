$goc  = "D:\2026\HK1\C-Sharp\Tuan05"          # thư mục chứa 5c và 5d
$dich = "$goc\5d\btvn2"                      # project gộp (có frmMain.cs, Program.cs, .csproj)

function ChuyenForm([string]$nguon, [string]$tenMoi) {
    foreach ($tep in Get-ChildItem $nguon -Filter *.cs | Where-Object { $_.Name -ne "Program.cs" }) {
        $nd  = Get-Content $tep.FullName -Raw -Encoding UTF8
        $ten = $tep.Name

        $nd = $nd -replace 'namespace\s+\w+', 'namespace BTVN_Tuan6'

        if ($ten -like "Form1*") {
            $nd  = $nd  -replace 'Form1', $tenMoi
            $ten = $ten -replace 'Form1', $tenMoi

            # form con bo qua hop thoai xac nhan khi form chinh dong
            $nd = [regex]::Replace($nd,
                '(private void \w+_FormClosing\(object\? sender, FormClosingEventArgs e\)\s*\{)',
                '$1' + [Environment]::NewLine + '            if (e.CloseReason == CloseReason.MdiFormClosing) return;')

            # menu cua form con khong gop vao menu cua form chinh
            $nd = $nd -replace 'menuChinh\.Name = "menuChinh";',
                  ('menuChinh.Name = "menuChinh";' + [Environment]::NewLine + '            menuChinh.AllowMerge = false;')
        }

        Set-Content (Join-Path $dich $ten) $nd -Encoding UTF8
    }
}

ChuyenForm "$goc\5c\bai1"     "frmCombobox"
ChuyenForm "$goc\5c\bai2"     "frmTreeLop"
ChuyenForm "$goc\5c\btvn1"    "frmTuDien"
ChuyenForm "$goc\5c\btvn2"    "frmListbox"
ChuyenForm "$goc\5c\btvn3"    "frmDanhBa"
ChuyenForm "$goc\5c\nangcao"  "frmChuoi"
ChuyenForm "$goc\5d\bai1"     "frmBaitap1"
ChuyenForm "$goc\5d\bai2"     "frmBaiTap2"
ChuyenForm "$goc\5d\btvn1"    "frmDongHo"
ChuyenForm "$goc\5d\nangcao"  "frmHocVien"