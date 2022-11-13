using UnityEngine;

[System.Serializable]
public class DateAndTime 
{
    public int day;
	
	public int month;
	
	public int year;
	
	public int hour;
	
	public int minutes;
	
	public int seconds;
	
	public int daySpent;

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