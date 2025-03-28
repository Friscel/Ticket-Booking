﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Booking_BusinessDataLogic
{
    public class BookingProcess
    {
        public static string[] _movies = { "Avengers: Endgame", "Inception", "Interstellar", "Joker" };
        public static int[] _availableTickets = { 55, 40, 30, 20 };

        public static int[] _bookedTickets = { 0, 0, 0, 0 };
        public static string[] GetMovies()
        {
            return _movies;
        }
        public static int[] GetAvailableTickets()
        {
            return _availableTickets;
        }
        //Method to update tickets based on action
        public static bool UpdateTickets(Actions action, int movieChoice, int amount)
        {
            if (movieChoice < 0 || movieChoice >= _movies.Length)
            {
                return false;
            }

            if (action == Actions.BookTicket)
            {
                if (_availableTickets[movieChoice] >= amount)
                {
                    _availableTickets[movieChoice] -= amount;
                    _bookedTickets[movieChoice] += amount;
                    return true;
                }
                return false;
            }
            if (action == Actions.CancelTicket)
            {
                if (_bookedTickets[movieChoice] >= amount)
                {
                    _availableTickets[movieChoice] += amount;
                    _bookedTickets[movieChoice] -= amount;
                    return true;
                }
                return false;
            }
            return false;
        }
        // Method to check ticket availability
        public static bool CheckTicketAvailability(int movieChoice, int amount)
        {
            if (movieChoice < 0 || movieChoice >= _movies.Length || amount <= 0)
            {
                return false;
            }
            return _availableTickets[movieChoice] >= amount;
        }
        // Method to get current available tickets for a movie
        public static int GetAvailableTicketsForMovie(int movieChoice)
        {
            if (movieChoice < 0 || movieChoice >= _movies.Length)
            {
                return -1;
            }
            return _availableTickets[movieChoice];
        }
        // Method to get booked tickets for a movie
        public static int GetBookedTicketsForMovie(int movieChoice)
        {
            if (movieChoice < 0 || movieChoice >= _movies.Length)
            {
                return -1;
            }
            return _bookedTickets[movieChoice];
        }
    }
}