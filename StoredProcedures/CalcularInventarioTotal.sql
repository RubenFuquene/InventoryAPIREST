CREATE OR REPLACE FUNCTION CalcularInventarioTotal()
RETURNS TABLE (
    ProductoId INT,
    Nombre VARCHAR,
    InventarioActual INT
)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY
    SELECT
        p."Id",
        p."Nombre",
        CalcularInventarioActual(p."Id") AS InventarioActual
    FROM
        public."Productos" p;
END;
$$;
