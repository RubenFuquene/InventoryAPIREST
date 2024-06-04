CREATE OR REPLACE FUNCTION CalcularInventarioActual(p_producto_id INT)
RETURNS INT
LANGUAGE plpgsql
AS $$
DECLARE
    inventario_actual INT;
BEGIN
    SELECT COALESCE(SUM(
        CASE
            WHEN "TipoMovimiento" = 'entrada' THEN "Cantidad"
            WHEN "TipoMovimiento" = 'salida' THEN -"Cantidad"
        END), 0) INTO inventario_actual
    FROM public."MovimientosInventario"
    WHERE "ProductoId" = p_producto_id;

    RETURN inventario_actual;
END;
$$;
