import React, { useEffect, useState } from 'react';
import { getHechos } from '../services/api';
import './Dashboard.css'; // Asegúrate de importar el CSS

function Dashboard() {
    const [hechos, setHechos] = useState([]);

    useEffect(() => {
        getHechos().then(res => setHechos(res.data));
    }, []);

    const totalVehiculos = hechos.reduce((sum, h) => sum + h.cantidadVehiculos, 0);
    const velocidadPromedio =
        hechos.length > 0
            ? (hechos.reduce((sum, h) => sum + h.velocidadPromKmh, 0) / hechos.length).toFixed(2)
            : 0;

    return (
        <div className="dashboard">
            <h2 className="dashboard-title">Dashboard de Trafico</h2>
            <div className="dashboard-grid">
                <div className="card card-blue">
                    <p className="card-title">Total vehículos</p>
                    <p className="card-value">{totalVehiculos}</p>
                </div>
                <div className="card card-green">
                    <p className="card-title">Velocidad promedio</p>
                    <p className="card-value">{velocidadPromedio} km/h</p>
                </div>
                <div className="card card-yellow">
                    <p className="card-title">Registros</p>
                    <p className="card-value">{hechos.length}</p>
                </div>
            </div>
        </div>
    );
}

export default Dashboard;