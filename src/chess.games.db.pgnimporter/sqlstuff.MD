/****** Script for SelectTopNRows command from SSMS  ******/
USE CHESSGAMES
SELECT count(*) from Games

SELECT 
	evts.Name as Event,
	sites.Name as Site,
	g.Date,
	g.Round,
	p1.Name as White,
	p2.Name as Black,
	g.Result,
	g.MoveText
  FROM [ChessGames].[dbo].[Games] as g
  join Players as p1 on g.WhiteId = p1.Id
  join Players as p2 on g.BlackId = p2.Id
  join Events as evts on g.EventId= evts.Id
  join Sites as sites on g.SiteId= sites.Id

  order by Event, Site,Round, White, Black, Result

/* Check for dupe movetext's
SELECT top 10 
	evts.Name as Event,
	sites.Name as Site,
	g.Date,
	g.Round,
	p1.Name as White,
	p2.Name as Black,
	g.Result,
	g.MoveText,
	COUNT(*)
FROM Games g
join Players as p1 on g.WhiteId = p1.Id
  join Players as p2 on g.BlackId = p2.Id
  join Events as evts on g.EventId= evts.Id
  join Sites as sites on g.SiteId= sites.Id
GROUP BY MoveText, evts.Name, sites.Name, Date, Round, p1.Name, p2.Name, Result
HAVING COUNT(*) > 1
order by count(*) desc
*/

select
	(select count(*) from games) as GamesCount,
	(select count(*) from events) as EventsCount,
	(select count(*) from sites) as SitesCount,
	(select count(*) from players) as PlayersCount


begin transaction

-- Merge Players
declare @srcId uniqueidentifier = '8BC2048F-3876-4B0E-FC6E-08D7231C4613'
declare @destId uniqueidentifier = '5CE61EBE-53C0-467A-FAB7-08D7231C4613'

update Games
set WhiteId = @destId
where WhiteId = @srcId

update Games
set BlackId = @destId
where BlackId = @srcId

delete from Players where Id = @srcId

commit
