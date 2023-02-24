import { test, expect } from '@playwright/test';

test('test', async ({ page }) => {
  await page.goto('http://eaapp.somee.com/');
  await page.getByRole('link', { name: 'Login' }).click();
  await page.getByLabel('UserName').click();
  await page.getByLabel('UserName').fill('admin');
  await page.getByLabel('UserName').press('Tab');
  await page.getByLabel('Password').fill('password');
  await page.getByRole('button', { name: 'Log in' }).click();
  await page.getByRole('link', { name: 'Employee Details' }).click();
});