﻿using Infrastructure.Domain.ReadModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manufactures.Domain.GarmentSewingOuts.ReadModels
{
	public class GarmentBalanceSewingReadModel : ReadModelBase
	{
		public GarmentBalanceSewingReadModel(Guid identity) : base(identity)
		{
		}
		public string RoJob { get; internal set; }
		public string Article { get; internal set; }
		public int UnitId { get; internal set; }
		public string UnitCode { get; internal set; }
		public string UnitName { get; internal set; }
		public string BuyerCode { get; internal set; }
		public double QtyOrder { get; internal set; }
		public string Style { get; internal set; }
		public double Hours { get; internal set; }
		public double Stock { get; internal set; }
		public double LoadingQtyPcs { get; internal set; }
		public double SewingOutQtyPcs { get; internal set; }
		public string UomUnit { get; internal set; }
		public double RemainQty { get; internal set; }
		public decimal Price { get; internal set; }
		public decimal Nominal { get; internal set; }

	}
}
