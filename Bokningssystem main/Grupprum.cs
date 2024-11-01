using Bokningssystem_main;
using System;

public class Grupprum: Lokal, IBookable
{
    public string GrupprumName { get; set; }
    public Grupprum()
	{
        
	}

    public void BookRoom()
    {
        throw new NotImplementedException();
    }

    public void ShowAvailableRooms()
    {
        throw new NotImplementedException();
    }

    public void ShowBookings()
    {
        throw new NotImplementedException();
    }

    public void UnbookRoom()
    {
        throw new NotImplementedException();
    }

    public void UpdateABooking()
    {
        throw new NotImplementedException();
    }
}
