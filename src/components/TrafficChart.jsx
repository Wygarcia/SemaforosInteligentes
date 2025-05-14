import './TrafficChart.css';
import React, { useEffect, useState } from 'react';
import { Bar } from 'react-chartjs-2';
import { getHechos } from '../services/api';
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    BarElement,
    Tooltip,
    Legend
} from 'chart.js';

ChartJS.register(CategoryScale, LinearScale, BarElement, Tooltip, Legend);

function TrafficChart() {
    const [hechos, setHechos] = useState([]);

    useEffect(() => {
        getHechos().then(res => setHechos(res.data));
    }, []);

    // Tomar solo los primeros 10 registros
    const primeros10 = hechos.slice(0, 10);

    const data = {
        labels: primeros10.map(h => `ID ${h.id}`),
        datasets: [
            {
                label: 'CANTIDAD DE VEHICULOS',
                data: primeros10.map(h => h.cantidadVehiculos),
                backgroundColor: '#36A2EB',
                borderRadius: 6,
                barThickness: 30
            },
            {
                label: 'TIEMPO DE ESPERA (seg)',
                data: primeros10.map(h => h.tiempoEsperaSeg),
                backgroundColor: '#FF6384',
                borderRadius: 6,
                barThickness: 30
            }
        ]
    };

    const options = {
        responsive: true,
        plugins: {
            legend: {
                position: 'top',
                labels: {
                    font: {
                        size: 14
                    }
                }
            },
            tooltip: {
                backgroundColor: '#333',
                titleColor: '#fff',
                bodyColor: '#fff',
            }
        },
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    font: {
                        size: 13
                    }
                }
            },
            x: {
                ticks: {
                    font: {
                        size: 13
                    }
                }
            }
        }
    };

    return (
        <div className="chart-container">
            
            <h2 className="chart-title">
                Vehiculos y Tiempos de Espera (Top 10 Registros)
            </h2>

            <Bar data={data} options={options} />
        </div>
    );
}

export default TrafficChart;

