using TrainOnline.Models;

namespace TrainOnline.Data
{
    public static class DataSeed
    {
        public static void Seeding (ApplicationDbContext context)
        {
            if (context.Stations.Count() <= 0)
            {
                var station1 = new Station()
                {
                    StationName = "Ga Hà Nội"
                };

                var station2 = new Station()
                {
                    StationName = "Ga Đà Nẵng"
                };

                var station3 = new Station()
                {
                    StationName = "Ga Hồ Chí Minh"
                };

                var station4 = new Station()
                {
                    StationName = "Ga Huế"
                };

                var station5 = new Station()
                {
                    StationName = "Ga Nha Trang"
                };

                var station6 = new Station()
                {
                    StationName = "Ga Đà Lạt"
                };

                context.Stations.Add(station1);
                context.Stations.Add(station1);
                context.Stations.Add(station1);
                context.Stations.Add(station1);
                context.Stations.Add(station1);
                context.Stations.Add(station1);
                context.SaveChanges();
            }

            if (context.Trains.Count () <= 0)
            {
                var train1 = new Train()
                {
                    TrainNumber = 3,
                    TypeId = 1,
                    StatusId = 2
                };
            }
        }
    }
}
