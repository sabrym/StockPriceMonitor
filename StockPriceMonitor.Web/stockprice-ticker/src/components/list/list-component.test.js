import { render, screen } from '@testing-library/react';
import List from './list-component';
import React from 'react';
/**
 * @jest-environment jsdom
 */

it('renders without crashing', () => {
    const div = document.createElement('div');
    render(<List />, div);
});

it('renders message if no items present', () => {
    render(<List />);
    expect(screen.getByTestId("stock-items").innerHTML).toEqual("<tr><td>No valid items</td></tr>");
});
