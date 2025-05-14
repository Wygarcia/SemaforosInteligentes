import React from 'react';
import Dashboard from './components/Dashboard.jsx';
import TrafficChart from './components/TrafficChart.jsx';
import TrafficTable from './components/TrafficTable.jsx';
import './index.css';

function App() {
    return (
        <div className="container">
            <h2 className="title-main">Panel de Semaforos Inteligentes</h2>
            {/* Renderiza el Dashboard una sola vez */}
            <Dashboard />

            {/* Secci�n de la gr�fica */}
            <TrafficChart />

            {/* Secci�n de la tabla */}
            <TrafficTable />
        </div>
    );
}

export default App;


