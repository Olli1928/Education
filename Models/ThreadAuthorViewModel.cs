using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Education.Models;

public class ThreadAuthorViewModel
{
    public List<Thr3ad>? Threads { get; set; }
    public SelectList? Authors { get; set; }
    public string? ThreadAuthor { get; set; }
    public string? SearchString { get; set; }
}
