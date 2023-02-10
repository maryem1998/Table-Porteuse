using AM.ApplicationCore;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
      public class FlightConfiguration : IEntityTypeConfiguration<Flight>
      {

            public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Flight> builder)
            {
        //Configurer la relation many-to - many entre la classe Flight et la classe Passenger
                builder.HasMany(f => f.Passengers).WithMany(f => f.Flights);
            //■ Configurer la relation one-to-many entre la classe Flight et la classe Plane

            builder.HasOne(f => f.Plane).WithMany(f => f.Flights); //.HasForeignKey(p => p.PlaneFK);

    }
}
}
