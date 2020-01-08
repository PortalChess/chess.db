/****** Script for SelectTopNRows command from SSMS  ******/
select count(*) from PgnGames
select count(*) from Games
select count(*) from Players
select count(*) from Sites
select count(*) from Events

select *, pgn.White, pgn.Black, len(lastname) from players p
join PlayerLookup as lk on p.Id = lk.PlayerId
join PgnGames as pgn on pgn.White = lk.Id or pgn.Black = lk.Id 
where lastname = 'Garcia'
order by firstname

select LastName, count(*) from players
group by lastname
order by count(*) desc

select Name, count(*) from Events
group by Name
order by count(*) desc

select Name, count(*) from Sites
group by Name
order by count(*) desc





/*
select count(*) from games

-- Show names that couldn't be matched
select e.Error, g.White, g.Black from PgnImportErrors e
join PgnGames g on g.Id = e.PgnGameId



delete from pgngames
delete from pgnimports

select * from pgngames where id = '4BB0A2A4-CDFE-4CE3-89C1-000685D9088F'
select white from pgngames where white like '%Aaberg%'
select * from Players where lastname = 'Aaberg'
select * from PgnImportErrors
select * from ImportedPgnGameIds

select * from players
  delete from EventLookup
  delete from SiteLookup
  delete from PlayerLookup
  delete from ImportedPgnGameIds
  delete from PgnImportErrors
  delete from players
  delete from events
  delete from sites
  delete from games
  */
