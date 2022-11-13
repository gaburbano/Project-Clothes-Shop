using UnityEngine;

[System.Serializable]
public class DateAndTime 
{
    int day;
	
    int month;
	
    int year;
	
    int hour;
	
    int minutes;
	
    int seconds;
	
	int daySpent;

	public DateAndTime(int day, int month, int year, int hour, int minutes, int seconds, int daySpent)
	{
		this.day = day;
		this.month = month;
		this.year = year;
		this.hour = hour;
		this.minutes = minutes;
		this.seconds = seconds;
		this.daySpent = daySpent;
	}
}