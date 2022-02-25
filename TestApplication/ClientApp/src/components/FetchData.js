import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

    componentDidMount() {
        setInterval(() => this.populateWeatherData(), 10000);
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
                    <th>Queue group name</th>
                    <th>Offered</th>
                    <th>Handled</th>
                    <th>Average talk time/TalkTime</th>
                    <th>Average handling
                        time/HandlingTime</th>
                    <th>Service Level</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
              <tr key={forecast.name}>
                  <td>{forecast.name}</td>
                  <td>{forecast.offered}</td>
                  <td>{forecast.handled}</td>
                  <td>{new Date(forecast.talkTime / forecast.handled * 1000).toISOString().substr(11, 8)}</td>
                  <td>{new Date(((forecast.talkTime + forecast.afterCallWorkTime) / forecast.handled) * 1000).toISOString().substr(11, 8)}</td>
                  <td className={forecast.color}>{Number(((forecast.handledWithinSL / forecast.offered)*100)).toFixed(1)}%</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }    
  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Queue</h1>       
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
      const response = await fetch('queue/GetMoniterData');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
