namespace test_1007
{
    partial class TestCSV
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenCSV = new System.Windows.Forms.Button();
            this.CSV_text = new System.Windows.Forms.TextBox();
            this.listBoxHeaders = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSearchKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearchResult = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenCSV
            // 
            this.buttonOpenCSV.Location = new System.Drawing.Point(12, 12);
            this.buttonOpenCSV.Name = "buttonOpenCSV";
            this.buttonOpenCSV.Size = new System.Drawing.Size(140, 40);
            this.buttonOpenCSV.TabIndex = 0;
            this.buttonOpenCSV.Text = "CSV 열기";
            this.buttonOpenCSV.UseVisualStyleBackColor = true;
            this.buttonOpenCSV.Click += new System.EventHandler(this.buttonOpenCSV_Click);
            // 
            // CSV_text
            // 
            this.CSV_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CSV_text.Font = new System.Drawing.Font("굴림", 8F);
            this.CSV_text.Location = new System.Drawing.Point(158, 302);
            this.CSV_text.Multiline = true;
            this.CSV_text.Name = "CSV_text";
            this.CSV_text.Size = new System.Drawing.Size(682, 190);
            this.CSV_text.TabIndex = 1;
            // 
            // listBoxHeaders
            // 
            this.listBoxHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxHeaders.FormattingEnabled = true;
            this.listBoxHeaders.ItemHeight = 12;
            this.listBoxHeaders.Location = new System.Drawing.Point(12, 95);
            this.listBoxHeaders.Name = "listBoxHeaders";
            this.listBoxHeaders.Size = new System.Drawing.Size(140, 400);
            this.listBoxHeaders.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "컬럼 헤더 리스트";
            // 
            // textBoxSearchKeyword
            // 
            this.textBoxSearchKeyword.Location = new System.Drawing.Point(164, 41);
            this.textBoxSearchKeyword.Name = "textBoxSearchKeyword";
            this.textBoxSearchKeyword.Size = new System.Drawing.Size(152, 21);
            this.textBoxSearchKeyword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "검색 키워드";
            // 
            // textBoxSearchResult
            // 
            this.textBoxSearchResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchResult.Font = new System.Drawing.Font("굴림", 8F);
            this.textBoxSearchResult.Location = new System.Drawing.Point(158, 154);
            this.textBoxSearchResult.Multiline = true;
            this.textBoxSearchResult.Name = "textBoxSearchResult";
            this.textBoxSearchResult.Size = new System.Drawing.Size(682, 139);
            this.textBoxSearchResult.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(164, 68);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(152, 62);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "검색하기";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // TestCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 530);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearchKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxHeaders);
            this.Controls.Add(this.textBoxSearchResult);
            this.Controls.Add(this.CSV_text);
            this.Controls.Add(this.buttonOpenCSV);
            this.Name = "TestCSV";
            this.Text = "CSV 검색기";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenCSV;
        private System.Windows.Forms.TextBox CSV_text;
        private System.Windows.Forms.ListBox listBoxHeaders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearchResult;
        private System.Windows.Forms.Button buttonSearch;
    }
}

