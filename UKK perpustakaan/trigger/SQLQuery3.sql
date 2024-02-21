CREATE TRIGGER kurangstok
ON peminjaman
AFTER INSERT 
AS
BEGIN
SET NOCOUNT ON;

DECLARE @idbuku INT;
SELECT @idbuku = idbuku
FROM inserted;

UPDATE buku 
SET stok = stok - 1 
WHERE idbuku = @idbuku;
END;