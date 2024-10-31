CREATE DATABASE qldtc;
USE qldtc;
-- 1. 
CREATE TABLE khach_hang (
    khach_hang_id INT PRIMARY KEY AUTO_INCREMENT,
    ten VARCHAR(100),
    email VARCHAR(100),
    sdt VARCHAR(15),
    dia_chi TEXT,
    diem_tich_luy INT DEFAULT 0
);
CREATE TABLE yeu_cau_thi_cong (
    yeu_cau_id INT PRIMARY KEY AUTO_INCREMENT,
    khach_hang_id INT,
    ngay_gui_yeu_cau DATE,
    tinh_trang VARCHAR(50) DEFAULT 'Chờ xử lý',lich_su_don_hang_mo_ta_yeu_cau TEXT,
    FOREIGN KEY (khach_hang_id) REFERENCES khach_hang(khach_hang_id)
);
CREATE TABLE thiet_ke_ho_ca (
    thiet_ke_id INT PRIMARY KEY AUTO_INCREMENT,
    ten_thiet_ke VARCHAR(100),
    mo_ta TEXT,
    chi_phi DECIMAL(15,2),
    hinh_anh_url VARCHAR(255)
);
CREATE TABLE bao_gia (
    bao_gia_id INT PRIMARY KEY AUTO_INCREMENT,
    yeu_cau_id INT,
    ngay_lap DATE,
    tong_chi_phi DECIMAL(15,2),
    tinh_trang VARCHAR(50) DEFAULT 'Chờ xác nhận',
    FOREIGN KEY (yeu_cau_id) REFERENCES yeu_cau_thi_cong(yeu_cau_id)
);
CREATE TABLE dich_vu (
    dich_vu_id INT PRIMARY KEY AUTO_INCREMENT,
    ten_dich_vu VARCHAR(100),
    mo_ta TEXT,
    gia DECIMAL(15,2)
);
CREATE TABLE dat_dich_vu (
    dat_dich_vu_id INT PRIMARY KEY AUTO_INCREMENT,
    khach_hang_id INT,
    dich_vu_id INT,
    ngay_dat DATE,
    tinh_trang VARCHAR(50) DEFAULT 'Chờ xử lý',
    ket_qua_thuc_hien TEXT,
    danh_gia INT,
    FOREIGN KEY (khach_hang_id) REFERENCES khach_hang(khach_hang_id),
    FOREIGN KEY (dich_vu_id) REFERENCES dich_vu(dich_vu_id)
);
CREATE TABLE nhan_vien (
    nhan_vien_id INT PRIMARY KEY AUTO_INCREMENT,
    ten VARCHAR(100),
    chuc_vu VARCHAR(100),
    sdt VARCHAR(15)
);
CREATE TABLE phan_cong_dich_vu (
    phan_cong_id INT PRIMARY KEY AUTO_INCREMENT,
    dat_dich_vu_id INT,
    nhan_vien_id INT,
    ngay_thuc_hien DATE,
    FOREIGN KEY (dat_dich_vu_id) REFERENCES dat_dich_vu(dat_dich_vu_id),
    FOREIGN KEY (nhan_vien_id) REFERENCES nhan_vien(nhan_vien_id)
);
-- 2  
CREATE TABLE khuyen_mai (
    khuyen_mai_id INT PRIMARY KEY AUTO_INCREMENT,
    ten_khuyen_mai VARCHAR(100),
    mo_ta TEXT,
    muc_giam FLOAT
);
CREATE TABLE chinh_sach (
    chinh_sach_id INT PRIMARY KEY AUTO_INCREMENT,
    loai_chinh_sach VARCHAR(50),
    noi_dung TEXT
);
CREATE TABLE feedback (
    feedback_id INT PRIMARY KEY AUTO_INCREMENT,
    khach_hang_id INT,
    noi_dung TEXT,
    danh_gia INT,
    ngay_gop_y DATE,
    FOREIGN KEY (khach_hang_id) REFERENCES khach_hang(khach_hang_id)
);
-- 3
CREATE TABLE lich_su_don_hang (
    don_hang_id INT PRIMARY KEY AUTO_INCREMENT,
    khach_hang_id INT,
    loai_don_hang VARCHAR(50), -- 'Thi công' hoặc 'Dịch vụ'
    ngay_dat DATE,
    tong_tien DECIMAL(15,2),
    FOREIGN KEY (khach_hang_id) REFERENCES khach_hang(khach_hang_id)
);
CREATE TABLE tich_diem (
    tich_diem_id INT PRIMARY KEY AUTO_INCREMENT,
    khach_hang_id INT,
    diem INT,
    ngay_tich_diem DATE,
    loai_diem VARCHAR(50) -- 'Thi công' hoặc 'Dịch vụ'
);


