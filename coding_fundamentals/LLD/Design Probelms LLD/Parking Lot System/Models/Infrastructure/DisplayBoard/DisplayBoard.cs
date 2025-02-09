using All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Interface;
using System.Collections.Generic;

namespace All.Design.Patterns.Design_Probelms_LLD.Parking_Lot_System.Models
{
    public class DisplayBoard
    {
        public int BoardId { get; set; }
        public Dictionary<string, List<ParkingSpot>> parkingSpots { get; set; }
        public DisplayBoard(int boardId)
        {
            this.BoardId = BoardId;
            parkingSpots = new Dictionary<string, List<ParkingSpot>>();
        }

        public void ShowFreeSlots() { }
        public void SendParkingFullNotification() { }
        public void AddBookedParkingSlot(string slotType, ParkingSpot parkingSpot)
        {

            if (!parkingSpots.TryGetValue(slotType, out var bookedPparkingSpots))
            {
                bookedPparkingSpots = new List<ParkingSpot>();
            }
            bookedPparkingSpots.Add(parkingSpot);
        }
    }
}