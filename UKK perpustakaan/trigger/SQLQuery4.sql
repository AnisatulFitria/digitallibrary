CREATE TRIGGER tambahstok
ON peminjaman
AFTER UPDATE
AS
BEGIN
SET NOCOUNT ON;

DECLARE @idbuku INT;

SELECT @idbuku = idbuku
FROM inserted;

IF (SELECT statuspeminjaman FROM inserted) = 'Dikembalikan'
BEGIN

UPDATE buku 
SET stok = stok + 1
WHERE idbuku = @idbuku;
END;
END;