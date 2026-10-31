import { test, expect } from '@playwright/test';

test('test', async ({ page }) => {
  await page.goto('about:blank');
  await page.goto('https://www.alextranwebsite.com/');
  await page.getByRole('heading', { name: '👋 Howdy' }).click();
  await page.getByText('I build web and mobile apps').click();
  const page1Promise = page.waitForEvent('popup');
  await page.getByRole('button', { name: ' Github' }).click();
  const page1 = await page1Promise;
  const page2Promise = page.waitForEvent('popup');
  await page.getByRole('button', { name: ' Résumé' }).click();
  const page2 = await page2Promise;
  const page3Promise = page.waitForEvent('popup');
  await page.getByRole('button', { name: ' Leetcode' }).click();
  const page3 = await page3Promise;
  await page.getByRole('img', { name: 'picture of Alex Tran' }).click();
  await page.getByRole('heading', { name: 'Alex at Niagara Falls' }).click();
  await page.locator('div').filter({ hasText: /^Alex at Niagara Falls$/ }).click();
});