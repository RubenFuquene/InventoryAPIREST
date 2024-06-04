DROP FUNCTION registrarmovimiento(integer,character varying,integer,text);
CREATE OR REPLACE FUNCTION RegistrarMovimiento(
    p_producto_id INT,
    p_tipo_movimiento VARCHAR,
    p_cantidad INT,
    p_descripcion TEXT
)
RETURNS TABLE (
    "Id" INT,
	"ProductoId" INT,
	"TipoMovimiento" VARCHAR(10),
	"Cantidad" INT,
	"FechaMovimiento" TIMESTAMP with time zone,
	"Descripcion" TEXT
) AS $$
DECLARE
    v_movimiento_id INT;
BEGIN
    INSERT INTO public."MovimientosInventario" ("ProductoId", "TipoMovimiento", "Cantidad", "FechaMovimiento", "Descripcion")
    VALUES (p_producto_id, p_tipo_movimiento, p_cantidad, CURRENT_TIMESTAMP, p_descripcion);

	v_movimiento_id := LASTVAL();

    PERFORM ActualizarStock(p_producto_id, p_cantidad, p_tipo_movimiento);

	RETURN QUERY
		SELECT
			v_movimiento_id,
			p_producto_id,
			p_tipo_movimiento,
			p_cantidad,
			CURRENT_TIMESTAMP,
			p_descripcion;
END;
$$ LANGUAGE plpgsql;