﻿using System;
using System.Collections.Generic;

namespace TradeAPI.Models;

public partial class Orderproduct
{
    public string OrderProductId { get; set; } = null!;

    public int OrderId { get; set; }

    public string ProductArticleNumber { get; set; } = null!;

    public int Count { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product ProductArticleNumberNavigation { get; set; } = null!;
}
