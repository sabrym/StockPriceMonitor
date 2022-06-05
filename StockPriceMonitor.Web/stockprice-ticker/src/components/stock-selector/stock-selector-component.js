import { Component, Fragment } from "react";
import List from "../list/list-component";
import Selector from "../select/select-component";

export default class StockSelector extends Component {
    stockApiUrl = 'https://localhost:7001/api';
    selectionTypes = {
        StockSource: 1,
        Stock: 2
    }

    constructor(props) {
        super(props);
        this.state = { stockSourceId: 0, stockId: 0, stockSources: [], stocks: [] };
    }

    componentDidMount() {
        this.getStockSourcesOnLoad();
    }

    getStockSourcesOnLoad() {
        fetch(`${this.stockApiUrl}/stocks`).then(res => res.json())
            .then((stockSources) => {
                if (stockSources) {
                    const defaultSource = stockSources[0];

                    this.setState({
                        stockSourceId: defaultSource.id,
                        stockId: defaultSource.stocks[0].id,
                        stocks: defaultSource.stocks,
                        stockSources: stockSources
                    });

                    return fetch(`${this.stockApiUrl}/stocks/get-prices/${defaultSource.id}/${defaultSource.stocks[0].id}`);
                }
            }).then(res => res.json()).then((stockPrices) => {
                this.setState({
                    stockPrices: stockPrices
                });
            });
    }

    onSelectionChange(selectionValue, selectionType) {
        if (selectionType === this.selectionTypes.StockSource) {
            this.setState({ stockSourceId: parseInt(selectionValue) }, () => {
                const newStocks = this.state.stockSources.find((item) => {
                    return item.id === this.state.stockSourceId;
                }).stocks;

                this.setState({ stocks: newStocks, stockId: this.state.stocks[0].id }, () => {
                    this.getStockPrices();
                });
            });
        }
        else {
            this.setState({ stockId: selectionValue }, () => {
                this.getStockPrices();
            });
        }
    }

    getStockPrices() {
        fetch(`${this.stockApiUrl}/stocks/get-prices/${this.state.stockSourceId}/${this.state.stockId}`).then(res => res.json()).then((stockPrices) => {
            this.setState({
                stockPrices: stockPrices
            });
        });
    }

    render() {
        return (
            <Fragment>
                <div data-testid="stock-selector">
                    <Selector onchange={this.onSelectionChange.bind(this)} items={this.state.stockSources} type={this.selectionTypes.StockSource} selectedValue={this.state.stockSourceId}></Selector>
                    <br />
                    <Selector onchange={this.onSelectionChange.bind(this)} items={this.state.stocks} type={this.selectionTypes.Stock} selectedValue={this.state.stockId}></Selector>
                    <br></br>
                    <List items={this.state.stockPrices}></List>
                </div>
            </Fragment>
        );
    }
}