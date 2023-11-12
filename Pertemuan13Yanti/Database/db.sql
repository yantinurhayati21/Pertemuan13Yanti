CREATE DATABASE pelatihan_pemrograman;
USE pelatihan_pemrograman;

CREATE TABLE Pelatihan(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nama_pelatihan VARCHAR(255) NOT NULL,
	deskripsi TEXT,
	tanggal_mulai DATE,
	tanggal_selesai DATE,		
	instruktur VARCHAR(100),
	lokasi VARCHAR(255),
	harga DECIMAL(10,2)
);

CREATE TABLE Peserta(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nama_peserta VARCHAR(255) NOT NULL,
	email VARCHAR(255),
	no_telepon VARCHAR(15)
);

CREATE TABLE Sertifikat(
	id INT AUTO_INCREMENT PRIMARY KEY,
	nama_sertifikat VARCHAR(255) NOT NULL,
	deskripsi TEXT,
	pelatihan_id INT,
	FOREIGN KEY (pelatihan_id) REFERENCES Pelatihan(id)
);

CREATE TABLE Registrasi(
	id INT AUTO_INCREMENT PRIMARY KEY,
	peserta_id INT,
	pelatihan_id INT,
	FOREIGN KEY (peserta_id) REFERENCES Peserta(id),
	FOREIGN KEY (pelatihan_id) REFERENCES Pelatihan(id)
);

CREATE TABLE Admin(
	username varchar(15) PRIMARY KEY,
	pass VARCHAR(15)
);

CREATE TABLE Mahasiswa(
	NIM INT PRIMARY KEY,
	Nama varchar(25),
	Tanggal_lahir date,
	Photo longblob
);

