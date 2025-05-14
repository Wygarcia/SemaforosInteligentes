import React, { useEffect, useState } from 'react';
import { getHechos } from '../services/api';
import './TrafficTable.css';

function TrafficTable() {
    const [hechos, setHechos] = useState([]);
    const [mostrarTodo, setMostrarTodo] = useState(false);

    useEffect(() => {
        getHechos().then(res => setHechos(res.data));
    }, []);

    const hechosMostrados = mostrarTodo ? hechos : hechos.slice(0, 10);

    return (
        <div className="traffic-table-container">
            <h2 className="table-title"> Registros de Trafico</h2>
            <table className="traffic-table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Vehiculos</th>
                        <th>Velocidad</th>
                    </tr>
                </thead>
                <tbody>
                    {hechosMostrados.map((h) => (
                        <tr key={h.id}>
                            <td>{h.id}</td>
                            <td>{h.cantidadVehiculos}</td>
                            <td>{h.velocidadPromKmh} km/h</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {/* Botón Mostrar más / menos */}
            {hechos.length > 10 && (
                <div className="ver-mas-container">
                    <button className="ver-mas-btn" onClick={() => setMostrarTodo(!mostrarTodo)}>
                        {mostrarTodo ? 'Mostrar menos' : 'Mostrar mas...'}
                    </button>
                </div>
            )}
        </div>
    );
}

export default TrafficTable;
