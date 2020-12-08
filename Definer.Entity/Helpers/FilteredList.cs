using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definer.Entity.Helpers
{
    public class FilteredList<T> where T : class
    {
        public IEnumerable<T> data { get; set; }

        public int totalItems { get; set; }

        public Filter filter { get; set; }

        public T filterModel { get; set; }


    }
    public class Filter
    {
        public Filter()
        {
            Keyword = "";
            pageSize = 10;
            page = 1;
            isDetailSearch = false;
        }

        public string Keyword { get; set; }

        public int page { get; set; }

        public int pageSize { get; set; }

        public Page pager { get; set; }

        public bool isDetailSearch { get; set; }

        public int PartnerID { get; set; }

        public int BranchID { get; set; }

    }
    public class Page
    {
        public Page(int totalItems, int pageSize, int currentPage = 1, int maxPages = 10)
        {
            //Toplam Sayfa Sayısı hesaplanıyor.
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            //Geçerli sayfanın aralık dışında olmadığından emin olmak 
            //1den küçükse 1, toplam sayfa sayısından büyükse Son sayfa atanıyor.
            if (currentPage < 1)
            {
                currentPage = 1;
            }
            else if (currentPage > totalPages)
            {
                currentPage = totalPages;
            }

            int startPage, endPage;
            if (totalPages <= maxPages)
            {
                //Toplam sayfa sayısı Maksimum sayfa sayısına ulaşmadıysa 
                //Başlangıç sayfasını 1, Bitiş sayfasını Toplam sayfa sayısına eşitliyoruz. 
                startPage = 1;
                endPage = totalPages;
            }
            else
            {
                //Toplam Sayfa sayısı Maksimum sayfa sayısına ulaştıysa
                //Başlangıç ve Bitiş sayfaları hesaplanıyor. 
                var maxPagesBeforeCurrentPage = (int)Math.Floor((decimal)maxPages / (decimal)2);
                var maxPagesAfterCurrentPage = (int)Math.Ceiling((decimal)maxPages / (decimal)2) - 1;
                if (currentPage <= maxPagesBeforeCurrentPage)
                {
                    //Geçerli sayfa başlangıç sayfasına yakınsa
                    startPage = 1;
                    endPage = maxPages;
                }
                else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
                {
                    //Geçerli sayfa bitiş sayfasına yakınsa
                    startPage = totalPages - maxPages + 1;
                    endPage = totalPages;
                }
                else
                {
                    //Geçerli sayfa ortalardaysa 
                    startPage = currentPage - maxPagesBeforeCurrentPage;
                    endPage = currentPage + maxPagesAfterCurrentPage;
                }
            }

            //Başlangıç ve bitiş Indexlerini hesaplıyoruz.
            var startIndex = (currentPage - 1) * pageSize;
            var endIndex = Math.Min(startIndex + pageSize - 1, totalItems - 1);

            //Başlangıç ve bitiş indexleri Eksi olamaz. 
            if (startIndex < 0 || endIndex < 0)
            {
                startIndex = 0;
                endIndex = 0;
            }

            //Hesaplanmış sayfa numaraları kolay kullanım için listeye ekleniyor. 
            var pages = Enumerable.Range(startPage, (endPage + 1) - startPage).ToList();

            //Hesaplanmış değerler atanıyor.
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            StartIndex = startIndex;
            EndIndex = endIndex;
            Pages = pages;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }
        public List<int> Pages { get; private set; }

    }
}
