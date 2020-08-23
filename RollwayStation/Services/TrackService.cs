using RollwayStation.Models;

namespace RollwayStation.Services
{
    public class TrackService
    {
        private readonly Store store;

        public TrackService(Store store)
        {
            this.store = store;
        }

        public void LayTrack(Die die)
        {
            var track = new Track();
            track.LayTrack(die);
            store.CurrentRound.TrackLaid = track;
        }

        public void PickUpTrack()
        {
            store.CurrentRound.TrackLaid = null;
        }
    }
}
