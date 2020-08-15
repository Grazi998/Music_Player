CREATE DATABASE [msc_ply];
GO
USE msc_ply ;
GO

create table artist
(
	id int IDENTITY(1,1) not null
		constraint artist_pk
			primary key,
	artistname VARCHAR(100) not null,
);
GO

create table song
(
	id int IDENTITY(1,1) not null
		constraint song_pk
			primary key,
	songname VARCHAR(100) not null,
	songlength integer not null,
	artist_id integer not null
	constraint song_artist_id_fk
	references artist
);
GO

create table msc_user
(
	id int IDENTITY(1,1) not null
		constraint msc_user_pk
			primary key,
	username VARCHAR(100) not null,
	email VARCHAR(50) not null
);
GO

create table playlist
(
	id int IDENTITY(1,1) not null
		constraint playlist_pk
			primary key,
	title VARCHAR(100) not null,
	msc_user_id integer not null
	constraint playlist_msc_user_id_fk
	references msc_user
);
GO

create table playlist_song
(
	playlist_id integer not null
		constraint playlist_song_playlist_id_fk
			references playlist,
	song_id integer not null
		constraint playlist_song_song_id_fk
			references song,
	constraint playlist_song_pk
		primary key (playlist_id, song_id)
);
GO