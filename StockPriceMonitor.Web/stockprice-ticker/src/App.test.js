import { render, screen } from '@testing-library/react';
import App from './App';
import React from 'react';
/**
 * @jest-environment jsdom
 */

 it('renders without crashing', () => {
  const div = document.createElement('div');
  render(<App />, div);
});

test('renders the stock selector component', () => {
  const app = render(<App />);
  expect(screen.getAllByTestId("stock-selector").length > 0).toBe(true);
});
