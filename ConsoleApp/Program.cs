using System;
using System.Threading.Tasks;
using AllegroApi;
using AllegroApi.Query.Offer;
using AllegroApi.Service.Offer;

namespace ConsoleApp
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var allegroApi = new AllegroRestClient();

            try
            {

                var result = await allegroApi.Query(new GetAllOffersQuery()
                {
                    Authorization = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2MjY3MzM5ODUsInVzZXJfbmFtZSI6IjczMDI2MDA5IiwianRpIjoiMjFmY2RjNTQtY2JhYy00MzQxLTgyNzUtMDEwNmNmMGEzODIyIiwiY2xpZW50X2lkIjoiY2Q0YmM4NjA3Y2M0NDM1NWFkMzhhYTZlNTY1ZmRiZjQiLCJzY29wZSI6WyJhbGxlZ3JvOmFwaTpvcmRlcnM6cmVhZCIsImFsbGVncm86YXBpOnByb2ZpbGU6d3JpdGUiLCJhbGxlZ3JvOmFwaTpzYWxlOm9mZmVyczp3cml0ZSIsImFsbGVncm86YXBpOmJpbGxpbmc6cmVhZCIsImFsbGVncm86YXBpOmNhbXBhaWducyIsImFsbGVncm86YXBpOmRpc3B1dGVzIiwiYWxsZWdybzphcGk6c2FsZTpvZmZlcnM6cmVhZCIsImFsbGVncm86YXBpOmJpZHMiLCJhbGxlZ3JvOmFwaTpvcmRlcnM6d3JpdGUiLCJhbGxlZ3JvOmFwaTphZHMiLCJhbGxlZ3JvOmFwaTpwYXltZW50czp3cml0ZSIsImFsbGVncm86YXBpOnNhbGU6c2V0dGluZ3M6d3JpdGUiLCJhbGxlZ3JvOmFwaTpwcm9maWxlOnJlYWQiLCJhbGxlZ3JvOmFwaTpyYXRpbmdzIiwiYWxsZWdybzphcGk6c2FsZTpzZXR0aW5nczpyZWFkIiwiYWxsZWdybzphcGk6cGF5bWVudHM6cmVhZCIsImFsbGVncm86YXBpOm1lc3NhZ2luZyJdLCJhbGxlZ3JvX2FwaSI6dHJ1ZX0.s3uF-0kqjKmhVwrvMhlIes6xRqZBruQix9mIA-ajucYlvnfDVP-2Uuz3kylZLaX3AjqNVFykN_-hgAUWFCb8uslW-mYcyS6yhZrHJ5LDNgRvA9iB7TQXR0ghMMchjrE18humqfI0M82SyDQnD6wrZOYAsBdnFGTuCqIDkmILFGSwCCtLFYXLG91QurBnWjpf_3DPaw-pan4kE115Fh878eB0FwuQdQxSPRX0LKVZPG1tobkUoFB5hYPSttvP_yw4q68uNT5QAWLiLBH2CcXCUZxFBK0ztgmBfjqKgQjok54qBIo2xY4Oe7gL-Q_Jt9ycvS7RxXQj_iXjdEO2fSc4jw",
                    PublicationStatus =  PublicationStatus.Active
                });

                foreach (var item in result)
                {
                    Console.WriteLine(item.Name);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}