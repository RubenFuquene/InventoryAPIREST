CREATE OR REPLACE FUNCTION ActualizarStock(p_producto_id INT, p_cantidad INT, p_tipo_movimiento VARCHAR)
RETURNS VOID
LANGUAGE plpgsql
AS $$
BEGIN
    IF p_tipo_movimiento = 'entrada' THEN
        UPDATE public."Productos"
        SET "Stock" = "Stock" + p_cantidad, "FechaActualizacion" = CURRENT_TIMESTAMP
        WHERE "Id" = p_producto_id;
    ELSIF p_tipo_movimiento = 'salida' THEN
        UPDATE public."Productos"
        SET "Stock" = "Stock" - p_cantidad, "FechaActualizacion" = CURRENT_TIMESTAMP
        WHERE "Id" = p_producto_id;
    END IF;
END;
$$;
